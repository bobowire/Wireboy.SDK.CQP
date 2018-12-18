using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wireboy.SDK.CQP.Events.Enums;

namespace Wireboy.SDK.CQP.Events
{
    [Description("酷Q事件:Type=21 私聊消息 - 好友")]
    public interface IPrivateMsgEvent : IWireboyEvent
    {
        void Handle(PrivateMsgContext context);
    }

    public class PrivateMsgContext
    {
        /// <summary>
        /// 消息内容
        /// </summary>
        public PrivateMessageType subType;
        /// <summary>
        /// 消息Id
        /// </summary>
        public int msgId;
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
