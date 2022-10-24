using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Skoruba.IdentityServer4.Admin.EntityFramework.Entities;
using Skoruba.IdentityServer4.Admin.EntityFramework.Interfaces;
using Skoruba.IdentityServer4.Admin.EntityFramework.Shared.Constants;
using Skoruba.IdentityServer4.Admin.EntityFramework.Shared.Entities.Identity;

namespace Skoruba.IdentityServer4.Admin.EntityFramework.Shared.DbContexts
{
    public class AdminIdentityDbContext : IdentityDbContext<UserIdentity, UserIdentityRole, string, UserIdentityUserClaim, UserIdentityUserRole, UserIdentityUserLogin, UserIdentityRoleClaim, UserIdentityUserToken>, IOrganizationDbContext
    {
        public AdminIdentityDbContext(DbContextOptions<AdminIdentityDbContext> options) : base(options)
        {

        }

        public DbSet<Corporation> Corporations { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<UserParty> UserParties { get; set; }
        public DbSet<UserCorporation> UserCorporations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            ConfigureIdentityContext(builder);
        }

        private void ConfigureIdentityContext(ModelBuilder builder)
        {
            builder.Entity<UserIdentityRole>().ToTable(TableConsts.IdentityRoles);
            builder.Entity<UserIdentityRoleClaim>().ToTable(TableConsts.IdentityRoleClaims);
            builder.Entity<UserIdentityUserRole>().ToTable(TableConsts.IdentityUserRoles);

            builder.Entity<UserIdentity>().ToTable(TableConsts.IdentityUsers);
            builder.Entity<UserIdentityUserLogin>().ToTable(TableConsts.IdentityUserLogins);
            builder.Entity<UserIdentityUserClaim>().ToTable(TableConsts.IdentityUserClaims);
            builder.Entity<UserIdentityUserToken>().ToTable(TableConsts.IdentityUserTokens);

            builder.Entity<Corporation>().ToTable(TableConsts.Corporations);
            builder.Entity<Party>().ToTable(TableConsts.Parties);
            builder.Entity<UserParty>(b =>
            {
                b.HasKey(r => new { r.UserId, r.PartyId });
                b.HasOne(m => m.Party).WithMany().HasForeignKey("PartyId");
                b.HasOne(m => m.User).WithMany().HasForeignKey("UserId");
                b.ToTable(TableConsts.UserParties);
            });
            builder.Entity<UserCorporation>(b =>
            {
                b.HasKey(r => new { r.UserId, r.CorpId });
                b.HasOne(m => m.Corporation).WithMany().HasForeignKey("CorpId");
                b.HasOne(m => m.User).WithMany().HasForeignKey("UserId");
                b.ToTable(TableConsts.UserCorporations);
            });
        }
    }
}