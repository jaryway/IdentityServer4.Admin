using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skoruba.IdentityServer4.Admin.EntityFramework.Entities
{
    public class CorpUserIdentity : IdentityUser
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
