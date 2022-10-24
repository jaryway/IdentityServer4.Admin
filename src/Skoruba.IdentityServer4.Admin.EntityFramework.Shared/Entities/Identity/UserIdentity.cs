using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Skoruba.IdentityServer4.Admin.EntityFramework.Shared.Entities.Identity
{
    public class UserIdentity : IdentityUser
    {
        /// <summary>
        /// 
        /// </summary>
        public ICollection<Corporation> Corporations { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Party> Parties { get; set; }
    }
}