
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Skoruba.AuditLogging.EntityFramework.Helpers.Common;
using System;
using System.Linq;
using System.Threading.Tasks;
using Skoruba.IdentityServer4.Admin.EntityFramework.Extensions.Extensions;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Skoruba.IdentityServer4.Admin.EntityFramework.Shared.Repositories.Interfaces;
using Skoruba.IdentityServer4.Admin.EntityFramework.Shared.Entities.Identity;
using Skoruba.IdentityServer4.Admin.EntityFramework.Extensions.Enums;
using IdentityServer4.EntityFramework.Entities;

namespace Skoruba.IdentityServer4.Admin.EntityFramework.Shared.Repositories
{
    public class OrganizationRepository<TDbContext, TUser> : IOrganizationRepository<TUser>
        where TUser : UserIdentity
        where TDbContext : DbContext, IOrganizationDbContext

    {
        protected readonly TDbContext _dbContext;
        protected readonly UserManager<TUser> _userManager;

        public bool AutoSaveChanges { get; set; } = true;

        public OrganizationRepository(TDbContext dbContext, UserManager<TUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<int> AddCorporationAsync(Corporation corporation)
        {

            await _dbContext.Corporations.AddAsync(corporation);
            return await AutoSaveChangesAsync();
        }

        public async Task<IList<Corporation>> GetUserCorporations(string userName)
        {
            return await _dbContext.Corporations.Where(m => m.Users.Any(n => n.UserName == userName)).ToListAsync();
        }

        public async Task<PagedList<TUser>> GetUsersAsync(string search, long corpId, int page = 1, int pageSize = 10)
        {
            var pagedList = new PagedList<TUser>();
            var orgUsers = _userManager.Users.Include(u => u.Corporations)
                .Where(u => u.Corporations.Any(c => c.Id == corpId))
                .Select(m => m)
                .AsNoTracking();
            var users = await orgUsers.PageBy(u => u.Id, page, pageSize).ToListAsync();

            pagedList.Data.AddRange(users);
            pagedList.TotalCount = await orgUsers.CountAsync();
            pagedList.PageSize = pageSize;

            return pagedList;
        }

        public async Task<int> RemoveCorporationAsync(Corporation corporation)
        {
            var corporationToDelete = await _dbContext.Corporations.Where(x => x.Id == corporation.Id).SingleOrDefaultAsync();
            _dbContext.Corporations.Remove(corporationToDelete);

            return await AutoSaveChangesAsync();
        }

        public async Task<int> UpdateCorporationAsync(Corporation corporation)
        {
            _dbContext.Corporations.Update(corporation);
            return await AutoSaveChangesAsync();
        }

        protected virtual async Task<int> AutoSaveChangesAsync()
        {
            return AutoSaveChanges ? await _dbContext.SaveChangesAsync() : (int)SavedStatus.WillBeSavedExplicitly;
        }

        public virtual async Task<int> SaveAllChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
