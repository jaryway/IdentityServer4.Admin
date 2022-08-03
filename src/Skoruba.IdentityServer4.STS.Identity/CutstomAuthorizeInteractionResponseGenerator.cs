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

namespace Skoruba.IdentityServer4.STS.Identity
{
    public class CutstomAuthorizeInteractionResponseGenerator : AuthorizeInteractionResponseGenerator
    {
        public CutstomAuthorizeInteractionResponseGenerator(ISystemClock clock,
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
            if (!response.IsLogin && !response.IsConsent)
            {
                return new InteractionResponse { RedirectUrl = "/tenants/choose" };
            }

            return response;
        }


    }
}
