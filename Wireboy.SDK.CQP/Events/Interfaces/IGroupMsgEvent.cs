using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wireboy.SDK.CQP.Events
{
    [Description("插件初始化事件")]
    public interface IGroupMsgEvent : IWireboyEvent
    {
        void Handle(GroupMsgContext context);
    }

    public class GroupMsgContext
    {
        public int subType;
        public int msgId;
        public long fromGroup;
        public long fromQQ;
        public string fromAnonymous;
        public string msg;
        public int font;
    }
}
