using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skoruba.IdentityServer4.Admin.EntityFramework.Shared.Entities.Identity
{
    public class Corporation
    {
        /// <summary>
        /// Key
        /// </summary>
        public virtual long Id { get; set; }
        /// <summary>
        /// 企业简称
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 全称
        /// </summary>
        public virtual string FullName { get; set; }

        /// <summary>
        /// 法人名称
        /// </summary>
        public virtual string LegalName { get; set; }
        /// <summary>
        /// 法人身份证号
        /// </summary>
        public virtual string LegalCode { get; set; }
        /// <summary>
        ///主体类型
        /// </summary>
        public virtual string TypeCnt { get; set; }
        /// <summary>   
        /// logo
        /// </summary>
        public virtual string Logo { get; set; }
        /// <summary>
        /// 企业状态
        /// </summary>
        public virtual int Status { get; set; }
        /// <summary>
        /// 企业地址
        /// </summary>
        public virtual string Address { get; set; }

        /// <summary>
        /// 部门信息
        /// </summary>
        public ICollection<Party> Parties { get; set; }

        public ICollection<UserIdentity> Users { get; set; }
    }
}
