using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Skoruba.IdentityServer4.Admin.EntityFramework.Entities;

namespace Skoruba.IdentityServer4.Admin.EntityFramework.Interfaces
{
    public interface IOrganizaitonDbContext<TUser> where TUser : IdentityUser
    {
        public DbSet<Corporation> Corporations { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<UserParty<TUser>> UserParties { get; set; }
        public DbSet<UserCorporation<TUser>> UserCorporations { get; set; }
    }
}
