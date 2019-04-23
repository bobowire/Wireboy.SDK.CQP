using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wireboy.SDK.CQP.SdkEvents.Enums
{
    /// <summary>
    /// 群消息类型
    /// </summary>
    public enum RequestGroupAddType
    {
        /// <summary>
        /// 未知类型
        /// </summary>
        Unknow = 0,
        /// <summary>
        /// 主动申请
        /// </summary>
        Self = 1,
        /// <summary>
        /// 被邀请
        /// </summary>
        Other = 2
    }
}
