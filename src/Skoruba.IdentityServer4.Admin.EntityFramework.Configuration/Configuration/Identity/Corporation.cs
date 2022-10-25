using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skoruba.IdentityServer4.Admin.EntityFramework.Configuration.Configuration.Identity
{
    public class Corporation
    {
        public string Name { get; set; }

        public List<Party> Parties { get; set; }

        public List<string> Users { get; set; }
    }
}
