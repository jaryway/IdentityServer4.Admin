using Microsoft.AspNetCore.Identity;
using Skoruba.AuditLogging.EntityFramework.Helpers.Common;
using Skoruba.IdentityServer4.Admin.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skoruba.IdentityServer4.Admin.EntityFramework.Repositories.Interfaces
{
    public interface IOrganizationRepository<TUser> where TUser : CorpUserIdentity
    {
        Task<PagedList<TUser>> GetUsersAsync(string search, long corpId, int page = 1, int pageSize = 10);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="corporation"></param>
        /// <returns></returns>
        Task<int> AddCorporationAsync(Corporation corporation);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="corporation"></param>
        /// <returns></returns>
        Task<int> UpdateCorporationAsync(Corporation corporation);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="corporation"></param>
        /// <returns></returns>
        Task<int> RemoveCorporationAsync(Corporation corporation);

    }
}
