using System;
namespace Skoruba.IdentityServer4.Admin.EntityFramework.Shared.Entities.Identity
{
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

