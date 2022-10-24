using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skoruba.AuditLogging.EntityFramework.Helpers.Common;
using Skoruba.IdentityServer4.Admin.EntityFramework.Shared.Entities.Identity;

namespace Skoruba.IdentityServer4.Admin.EntityFramework.Shared.Repositories.Interfaces
{
    public interface IOrganizationRepository<TUser> where TUser : UserIdentity
    {
        Task<PagedList<TUser>> GetUsersAsync(string search, long corpId, int page = 1, int pageSize = 10);

        Task<IList<Corporation>> GetUserCorporations(string userName);

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

        Task<int> SaveAllChangesAsync();

        bool AutoSaveChanges { get; set; }
    }
}
