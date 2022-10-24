using Skoruba.IdentityServer4.Admin.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skoruba.IdentityServer4.Admin.EntityFramework.Shared.Entities.Identity;

namespace Skoruba.IdentityServer4.Admin.EntityFramework.Shared
{
    public interface IOrganizationDbContext
    {
        DbSet<Corporation> Corporations { get; set; }
        DbSet<Party> Parties { get; set; }
        DbSet<UserParty> UserParties { get; set; }
        DbSet<UserCorporation> UserCorporations { get; set; }
    }
}
