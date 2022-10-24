using System;
namespace Skoruba.IdentityServer4.Admin.EntityFramework.Shared.Entities.Identity
{
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

