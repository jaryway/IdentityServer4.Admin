using IdentityServer4.Models;
using IdentityServer4.ResponseHandling;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skoruba.IdentityServer4.STS.Identity.Helpers
{
    public class TenantChooserResponseGenerator : AuthorizeInteractionResponseGenerator
    {
        public TenantChooserResponseGenerator(ISystemClock clock,
            ILogger<AuthorizeInteractionResponseGenerator> logger,
            IConsentService consent, IProfileService profile) : base(clock, logger, consent, profile)
        {
            
        }
        public override async Task<InteractionResponse> ProcessInteractionAsync(ValidatedAuthorizeRequest request, ConsentResponse consent = null)
        {
            var tenant = request.GetTenant();
            //throw new NotImplementedException();
            //

            

            var response = await base.ProcessInteractionAsync(request, consent);
            // 用户登录后去选择要进入的租户
            // TODO:如果是已经选择了企业，第二次进入是否还需要再展示企业选择界面呢？
            if (!request.Subject.HasClaim(c => c.Type == TenantConstants.ClaimType && c.Value != ""))
            {
                return new InteractionResponse { RedirectUrl = "/tenant/choose" };
            }

            return response;
        }


    }
}
