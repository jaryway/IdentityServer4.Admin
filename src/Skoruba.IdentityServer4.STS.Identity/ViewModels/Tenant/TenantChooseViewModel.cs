using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skoruba.IdentityServer4.STS.Identity.ViewModels.Tenant
{
    public class TenantChooseViewModel
    {
        public string ReturnUrl { get; set; }

        public IList<string> Corperations { get; set; }
    }
}
