using System;
namespace Skoruba.IdentityServer4.Admin.EntityFramework.Shared.Entities.Identity
{
    public class Party
    {
        /// <summary>
        /// ID
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Authority { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int DisplayOrder { get; set; }
        /// <summary>
        /// 是否锁定
        /// </summary>
        public Boolean IsLocked { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OpenApiPartyId { get; set; }
        /// <summary>
        /// 父级ID
        /// </summary>
        public long ParentId { get; set; }
        ///// <summary>
        ///// 部门ID
        ///// </summary>
        //public long Id { get; set; }
        /// <summary>
        /// Id 路径
        /// </summary>
        public string PathIds { get; set; }
        /// <summary>
        /// 拼音全拼
        /// </summary>
        public string Pinyin { get; set; }
        /// <summary>
        /// 拼音首字母
        /// </summary>
        public string Py { get; set; }
        /// <summary>
        /// 所属公司
        /// </summary>
        public Corporation Corporation { get; set; }

    }
}

