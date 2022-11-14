using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skoruba.IdentityServer4.STS.Identity.ViewModels.Tenant
{

    public class ChooseInputViewModel
    {
        public string ReturnUrl { get; set; }

        public string CorpId { get; set; }
    }
}
