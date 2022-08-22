using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skoruba.IdentityServer4.Admin.EntityFramework.Entities
{

    /// <summary>
    /// 人员与企业映射表
    /// </summary>
    public class UserCorporation
    {
        public string UserId { get; set; }

        public long CorpId { get; set; }

        /// <summary>
        /// 状态，已邀请，邀请成功
        /// </summary>
        public string Status { get; set; }

        public UserIdentity User { get; set; }
        public Corporation Corporation { get; set; }
    }
}
