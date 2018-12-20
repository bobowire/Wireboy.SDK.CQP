using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wireboy.SDK.CQP.Core.Enums
{
    /// <summary>
    /// 日志等级
    /// </summary>
    public enum LogerLevel
    {
        /// <summary>
        /// 调试 灰色
        /// </summary>
        Debug = 0,
        /// <summary>
        /// 信息 黑色
        /// </summary>
        Info = 10,
        /// <summary>
        /// 信息_成功 紫色
        /// </summary>
        Info_Success = 11,
        /// <summary>
        /// 信息_接收 蓝色
        /// </summary>
        Info_Receive = 12,
        /// <summary>
        /// 信息_发送 绿色
        /// </summary>
        Info_Send = 13,
        /// <summary>
        /// 警告 橙色
        /// </summary>
        Warning = 20,
        /// <summary>
        /// 错误 红色
        /// </summary>
        Error = 30,
        /// <summary>
        /// 严重错误 深红
        /// </summary>
        Fatal = 40
    }
}
