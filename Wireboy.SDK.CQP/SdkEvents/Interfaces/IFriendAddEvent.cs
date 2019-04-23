using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wireboy.SDK.CQP.SdkEvents.Enums;

namespace Wireboy.SDK.CQP.SdkEvents
{
    [Description("酷Q事件:Type=201 好友已添加")]
    public interface IFriendAddEvent : IWireboyEvent
    {
        void Handle(FriendAddContext context);
    }

    public class FriendAddContext
    {
        /// <summary>
        /// 类型
        /// </summary>
        public FriendAddType subType;
        /// <summary>
        /// 时间
        /// </summary>
        public int sendTime;
        /// <summary>
        /// 来源QQ
        /// </summary>
        public long fromQQ;
    }
}
