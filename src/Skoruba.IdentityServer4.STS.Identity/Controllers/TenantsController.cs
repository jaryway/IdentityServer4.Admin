using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skoruba.IdentityServer4.STS.Identity.Controllers
{
    [Route("tenants")]
    public class TenantsController : Controller
    {

        [Route("choose")]
        [HttpGet]
        public IActionResult Choose()
        {
            var IsAuthenticated = HttpContext.User.Identity.IsAuthenticated;
            var userName = HttpContext.User.Identity.Name;

            // 根据用户名查找所有的租户

            return View();
        }

        [Route("choose")]
        [HttpPost]
        public IActionResult Choose([FromForm]FormCollection form )
        {
            var IsAuthenticated = HttpContext.User.Identity.IsAuthenticated;
            var userName = HttpContext.User.Identity.Name;

            // 根据用户名查找所有的租户

            return View();
        }
    }
}
