using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Skoruba.AuditLogging.EntityFramework.Helpers.Common;
using Skoruba.IdentityServer4.Admin.EntityFramework.Entities;
using Skoruba.IdentityServer4.Admin.EntityFramework.Interfaces;
using Skoruba.IdentityServer4.Admin.EntityFramework.Repositories.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using Skoruba.IdentityServer4.Admin.EntityFramework.Extensions.Extensions;
using System.Collections.Generic;

namespace Skoruba.IdentityServer4.Admin.EntityFramework.Repositories
{
    public class OrganizationRepository<TDbContext, TUser> : IOrganizationRepository<TUser>
        where TDbContext : IOrganizationDbContext
        where TUser : UserIdentity
    {

        protected readonly TDbContext _dbContext;
        protected readonly UserManager<TUser> _userManager;
        public OrganizationRepository(TDbContext dbContext, UserManager<TUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }
        public async Task<PagedList<TUser>> GetUsersAsync(string search, long corpId, int page = 1, int pageSize = 10)
        {
            var pagedList = new PagedList<TUser>();
            var orgUsers = _userManager.Users.Include(x => x.Corporations)
                .Where(x => x.Corporations.Any(m => m.Id == corpId))
                .Select(m => m)
                .AsNoTracking();
            var users = await orgUsers.PageBy(x => x.Id, page, pageSize).ToListAsync();

            pagedList.Data.AddRange(users);
            pagedList.TotalCount = await orgUsers.CountAsync();
            pagedList.PageSize = pageSize;

            return pagedList;

            //throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<IList<Corporation>> GetUserCorporations(string userName)
        {
            var corporations = await _dbContext.Corporations
                 .Where(m => m.Users.Any(u => u.UserName == userName))
                 .Select(m => m)
                 .ToListAsync();

            return corporations;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="corporation"></param>
        /// <returns></returns>
        public async Task<int> AddCorporationAsync(Corporation corporation)
        {

            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="corporation"></param>
        /// <returns></returns>
        public async Task<int> UpdateCorporationAsync(Corporation corporation)
        {

            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="corporation"></param>
        /// <returns></returns>
        public async Task<int> RemoveCorporationAsync(Corporation corporation)
        {

            throw new NotImplementedException();
        }


    }
}
