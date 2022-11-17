using AutoMapper;
using Microsoft.EntityFrameworkCore.Sqlite.Storage.Internal;
using Skoruba.IdentityServer4.Admin.BusinessLogic.Tenant.Dtos;
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
    public class TenantMapperProfile : Profile
    {
        public TenantMapperProfile()
        {
            CreateMap<Corporation, CorporationDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<Corporation, SelectItem>(MemberList.Destination)
                .ForMember(x => x.Text, opt => opt.MapFrom(src => src.FullName));

        }
    }
}
