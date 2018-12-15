using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wireboy.SDK.CQP.Events.Enums
{
    /// <summary>
    /// 群消息类型
    /// </summary>
    public enum GroupAdminType
    {
        /// <summary>
        /// 未知类型
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// 设为管理员
        /// </summary>
        ToAdmin = 1,
        /// <summary>
        /// 取消管理员
        /// </summary>
        ToMember = 2
    }
}
