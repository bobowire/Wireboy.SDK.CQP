using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wireboy.SDK.CQP.SdkEvents.Enums;

namespace Wireboy.SDK.CQP.SdkEvents
{
    [Description("酷Q事件:Type=301 请求-好友添加")]
    public interface IRequestAddFriendEvent : IWireboyEvent
    {
        void Handle(RequestAddFriendContext context);
    }

    public class RequestAddFriendContext
    {
        /// <summary>
        /// 类型
        /// </summary>
        public RequestFriendAddType subType;
        /// <summary>
        /// 时间
        /// </summary>
        public int sendTime;
        /// <summary>
        /// 来源QQ
        /// </summary>
        public long fromQQ;
        /// <summary>
        /// 验证消息内容
        /// </summary>
        public string msg;
        /// <summary>
        /// 反馈标识（用于处理请求）
        /// </summary>
        public string responseFlag;
    }
}
