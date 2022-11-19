using Skoruba.IdentityServer4.Admin.BusinessLogic.Tenant.Services.Interfaces;
using Skoruba.IdentityServer4.Admin.EntityFramework.Extensions.Common;
using Skoruba.IdentityServer4.Admin.EntityFramework.Shared.Entities.Identity;
using Skoruba.IdentityServer4.Admin.EntityFramework.Shared.Repositories.Interfaces;
using Skoruba.IdentityServer4.Admin.BusinessLogic.Tenant.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skoruba.IdentityServer4.Admin.BusinessLogic.Tenant.Dtos;
using Skoruba.IdentityServer4.Admin.BusinessLogic.Shared.ExceptionHandling;

namespace Skoruba.IdentityServer4.Admin.BusinessLogic.Tenant.Services
{
    public class TenantService : ITenantService
    {
        protected readonly IOrganizationRepository<UserIdentity> _organizationRepository;

        public TenantService(IOrganizationRepository<UserIdentity> organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public async Task<IList<SelectItem>> GetUserCorporations(string userName)
        {
            var corporations = await _organizationRepository.GetUserCorporations(userName);
            return corporations.Select(m => m.ToSelectItem()).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="corporation"></param>
        /// <returns></returns>
        public async Task<int> AddCorporationAsync(CorporationDto corporation)
        {
            var corporationEntity = corporation.ToEntity();
            return await _organizationRepository.AddCorporationAsync(corporationEntity);
        }

        public async Task<int> UpdateCorporationAsync(CorporationDto corporation)
        {
            var corporationEntity = corporation.ToEntity();
            return await _organizationRepository.AddCorporationAsync(corporationEntity);
        }
    }
}
