using IdentityServer4;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Skoruba.IdentityServer4.Admin.EntityFramework.Entities;
using Skoruba.IdentityServer4.Admin.EntityFramework.Repositories.Interfaces;
using Skoruba.IdentityServer4.Admin.EntityFramework.Shared.Entities.Identity;
using Skoruba.IdentityServer4.Admin.EntityFramework.Shared.Repositories.Interfaces;
using Skoruba.IdentityServer4.STS.Identity.Helpers;
using Skoruba.IdentityServer4.STS.Identity.ViewModels.Tenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Skoruba.IdentityServer4.STS.Identity.Controllers
{
    [Route("tenant")]
    public class TenantController<TUser, TKey> : Controller
        where TUser : IdentityUser<TKey>, new()
        where TKey : IEquatable<TKey>
    {

        protected readonly IOrganizationRepository<UserIdentity> _organizationRepository;
        protected readonly UserResolver<TUser> _userResolver;
        protected readonly UserManager<TUser> _userManager;
        protected readonly ApplicationSignInManager<TUser> _signInManager;
        public TenantController(IOrganizationRepository<UserIdentity> organizationRepository,
            UserResolver<TUser> userResolver,
            UserManager<TUser> userManager, ApplicationSignInManager<TUser> signInManager)
        {
            _organizationRepository = organizationRepository;
            _userResolver = userResolver;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Route("choose")]
        [HttpGet]
        public IActionResult Choose(string returnUrl)
        {

            var IsAuthenticated = HttpContext.User.Identity.IsAuthenticated;
            var userName = HttpContext.User.Identity.Name;

            //var userCorporations = _organizationRepository.GetUserCorporations(userName);
            var corperations = new List<CorperationViewModel>();
            corperations.Add(new CorperationViewModel { Id = "baidu", Name = "百度科技", });
            corperations.Add(new CorperationViewModel { Id = "haoyun", Name = "好运来科技", });
            corperations.Add(new CorperationViewModel { Id = "xiongxin", Name = "雄心科技", });

            var model = new ChooseViewModel
            {
                ReturnUrl = returnUrl,
                Corperations = corperations
            };

            // 根据用户名查找所有的租户

            return View(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("choose")]
        [HttpPost]
        public async Task<IActionResult> Choose(ChooseInputViewModel model)
        {
            var IsAuthenticated = HttpContext.User.Identity.IsAuthenticated;
            var userName = HttpContext.User.Identity.Name;

            if (!IsAuthenticated)
            {
                return RedirectToAction(nameof(AccountController<TUser, TKey>.Login), "Account", new { model.ReturnUrl });
            }

            #region 方式一

            var username = HttpContext.User.Identity.Name;
            var user = await _userResolver.GetUserAsync(username);
            var additionalClaims = new List<Claim> { new Claim(TenantConstants.ClaimType, model.CorpId) };

            await _signInManager.SignInWithClaimsAsync(user, true, additionalClaims);

            #endregion



            #region MyRegion
            //var identity = new ClaimsIdentity(new ClaimsIdentity(IdentityServerConstants.DefaultCookieAuthenticationScheme));
            //var claimsPrincipal = new ClaimsPrincipal(identity);
            //claimsPrincipal.Claims.Append(new Claim(TenantConstants.ClaimType, model.CorpId));

            //var sub = User.Claims.Single(r => r.Type == "sub").Value;

            //await HttpContext.SignInAsync(IdentityServerConstants.DefaultCookieAuthenticationScheme, claimsPrincipal); 
            #endregion


            return Redirect(model.ReturnUrl);
        }
    }
}
