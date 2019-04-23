using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wireboy.SDK.CQP.SdkEvents.Enums;

namespace Wireboy.SDK.CQP.SdkEvents
{
    [Description("酷Q事件:Type=101 群事件-管理员变动")]
    public interface IGroupAdminEvent : IWireboyEvent
    {
        void Handle(GroupAdminContext context);
    }

    public class GroupAdminContext
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        public GroupAdminType subType;
        /// <summary>
        /// 时间
        /// </summary>
        public int sendTime;
        /// <summary>
        /// 来源群
        /// </summary>
        public long fromGroup;
        /// <summary>
        /// 被操作QQ
        /// </summary>
        public long beingOperateQQ;
    }
}
