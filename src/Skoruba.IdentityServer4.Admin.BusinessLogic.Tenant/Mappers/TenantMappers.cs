using AutoMapper;
using Microsoft.EntityFrameworkCore.Sqlite.Storage.Internal;
using Skoruba.IdentityServer4.Admin.BusinessLogic.Tenant.Dtos;
//using Skoruba.IdentityServer4.Admin.EntityFramework.Configuration.Configuration.Identity;
using Skoruba.IdentityServer4.Admin.EntityFramework.Entities;
using Skoruba.IdentityServer4.Admin.EntityFramework.Extensions.Common;
using Skoruba.IdentityServer4.Admin.EntityFramework.Shared.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skoruba.IdentityServer4.Admin.BusinessLogic.Tenant.Mappers
{
    public static class TenantMappers
    {
        internal static IMapper Mapper { get; }

        static TenantMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<TenantMapperProfile>())
                .CreateMapper();
        }

        public static SelectItem ToSelectItem(this Corporation corporation)
        {
            return Mapper.Map<SelectItem>(corporation);
        }

        public static CorporationDto ToModel(this Corporation corporation)
        {
            return Mapper.Map<CorporationDto>(corporation);
        }
        public static Corporation ToEntity(this CorporationDto corporationDto)
        {
            return Mapper.Map<Corporation>(corporationDto);
        }
    }
}
