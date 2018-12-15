using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wireboy.SDK.CQP.Events.Enums;

namespace Wireboy.SDK.CQP.Events
{
    [Description("酷Q事件:Type=103 群事件-群成员增加")]
    public interface IGroupMemberIncreaseEvent : IWireboyEvent
    {
        void Handle(GroupMemberIncreaseContext context);
    }

    public class GroupMemberIncreaseContext
    {
        /// <summary>
        /// 加群途径
        /// </summary>
        public GroupMemberIncreasedType subType;
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
        /// 新成员QQ
        /// </summary>
        public long beingOperateQQ;
    }
}
