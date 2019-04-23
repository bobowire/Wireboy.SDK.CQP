using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wireboy.SDK.CQP.SdkEvents.Enums;

namespace Wireboy.SDK.CQP.SdkEvents
{
    [Description("酷Q事件:Type=2 群消息")]
    public interface IGroupMsgEvent : IWireboyEvent
    {
        void Handle(GroupMsgContext context);
    }

    public class GroupMsgContext
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        public GroupMessageType subType;
        /// <summary>
        /// 消息Id
        /// </summary>
        public int msgId;
        /// <summary>
        /// 来源群
        /// </summary>
        public long fromGroup;
        /// <summary>
        /// 来源QQ
        /// </summary>
        public long fromQQ;
        /// <summary>
        /// 匿名信息
        /// </summary>
        public string fromAnonymous;
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
