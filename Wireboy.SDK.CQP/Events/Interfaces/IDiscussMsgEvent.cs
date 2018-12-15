using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wireboy.SDK.CQP.Events.Enums;

namespace Wireboy.SDK.CQP.Events
{
    [Description("酷Q事件:Type=4 讨论组消息")]
    public interface IDiscussMsgEvent : IWireboyEvent
    {
        void Handle(DiscussMsgContext context);
    }

    public class DiscussMsgContext
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        public DiscussMessageType subType;
        /// <summary>
        /// 消息Id
        /// </summary>
        public int msgId;
        /// <summary>
        /// 来源讨论组
        /// </summary>
        public long fromDiscuss;
        /// <summary>
        /// 来源QQ
        /// </summary>
        public long fromQQ;
        /// <summary>
        /// 消息内容
        /// </summary>
        public string msg;
        /// <summary>
        /// 字体
        /// </summary>
        public int font;
    }
}
