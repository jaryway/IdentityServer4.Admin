﻿using System.Collections.Generic;
using Skoruba.IdentityServer4.Admin.EntityFramework.Configuration.Configuration.Identity;

namespace Skoruba.IdentityServer4.Admin.EntityFramework.Configuration.Configuration.IdentityServer
{
    public class Client : global::Jaryway.IdentityServer.Models.Client
    {
        public List<Claim> ClientClaims { get; set; } = new List<Claim>();
    }
}
