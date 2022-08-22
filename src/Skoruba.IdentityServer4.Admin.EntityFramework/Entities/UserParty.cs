using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skoruba.IdentityServer4.Admin.EntityFramework.Entities
{
    /// <summary>
    /// 用户与部门的映射表
    /// </summary>
    public class UserParty
    {
        public string UserId { get; set; }

        public long PartyId { get; set; }

        /// <summary>
        /// 在当前部门中的排序
        /// </summary>
        public long DisplayOrder { get; set; }

        /// <summary>
        /// 是否是主部门
        /// </summary>
        public byte IsMainParty { get; set; }

        public UserIdentity User { get; set; }

        public Party Party { get; set; }
    }
}
