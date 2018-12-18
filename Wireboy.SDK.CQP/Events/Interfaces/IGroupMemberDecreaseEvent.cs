using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wireboy.SDK.CQP.Events.Enums;

namespace Wireboy.SDK.CQP.Events
{
    [Description("酷Q事件:Type=102 群事件-群成员减少")]
    public interface IGroupMemberDecreaseEvent : IWireboyEvent
    {
        void Handle(GroupMemberDecreaseContext context);
    }

    public class GroupMemberDecreaseContext
    {
        /// <summary>
        /// 离开原因
        /// </summary>
        public GroupMemberDecreaseType subType;
        /// <summary>
        /// 时间
        /// </summary>
        public int sendTime;
        /// <summary>
        /// 来源群
        /// </summary>
        public long fromGroup;
        /// <summary>
        /// 操作者QQ
        /// </summary>
        public long fromQQ;
        /// <summary>
        /// 离开者QQ
        /// </summary>
        public long beingOperateQQ;
    }
}
