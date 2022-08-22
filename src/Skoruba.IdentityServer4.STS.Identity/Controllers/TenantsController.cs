﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Skoruba.IdentityServer4.Admin.EntityFramework.Entities;
using Skoruba.IdentityServer4.Admin.EntityFramework.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skoruba.IdentityServer4.STS.Identity.Controllers
{
    [Route("tenants")]
    public class TenantsController : Controller
    {

        protected readonly IOrganizationRepository<UserIdentity> _organizationRepository;
        public TenantsController(IOrganizationRepository<UserIdentity> organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        [Route("choose")]
        [HttpGet]
        public IActionResult Choose()
        {

            var IsAuthenticated = HttpContext.User.Identity.IsAuthenticated;
            var userName = HttpContext.User.Identity.Name;

            var userCorporations = _organizationRepository.GetUserCorporations(userName);

            // 根据用户名查找所有的租户

            return View();
        }

        [Route("choose")]
        [HttpPost]
        public IActionResult Choose([FromForm] FormCollection form)
        {
            var IsAuthenticated = HttpContext.User.Identity.IsAuthenticated;
            var userName = HttpContext.User.Identity.Name;

            // 根据用户名查找所有的租户

            return View();
        }
    }
}
