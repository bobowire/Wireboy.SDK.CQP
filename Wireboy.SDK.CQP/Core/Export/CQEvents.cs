using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Wireboy.SDK.CQP.Events;
using Wireboy.SDK.CQP.Modles;

namespace Wireboy.SDK.CQP.Core
{
    public class CQEvents
    {
        [DllExport(ExportName = "AppInfo", CallingConvention = CallingConvention.StdCall)]
        private static string AppInfo()
        {
            return string.Format("{0},{1}", AppInfo_Const.AppVersion, AppInfo_Const.AppId);
        }

        [DllExport(ExportName = "Initialize", CallingConvention = CallingConvention.StdCall)]
        private static int Initialize(int authCode)
        {
            RobbotManager.AuthCode = authCode;
            return 0;
        }

        [DllExport(ExportName = "_eventStartup", CallingConvention = CallingConvention.StdCall)]
        private static int EventStartUp()
        {
            CQ.AddLog(Core.Enums.LogerLevel.Info, "提示", "进来初始化了！");
            return 0;
        }

        [DllExport(ExportName = "_eventExit", CallingConvention = CallingConvention.StdCall)]
        private static int EventExit()
        {
            return 0;
        }

        [DllExport(ExportName = "_eventEnable", CallingConvention = CallingConvention.StdCall)]
        private static int EventEnable()
        {
            return 0;
        }

        [DllExport(ExportName = "_eventDisable", CallingConvention = CallingConvention.StdCall)]
        private static int EventDisable()
        {
            return 0;
        }

        [DllExport(ExportName = "_eventPrivateMsg", CallingConvention = CallingConvention.StdCall)]
        private static int EventPrivateMsg(int subType, int msgId, long fromQQ, string msg, int font)
        {
            return 0;
        }

        [DllExport(ExportName = "_eventGroupMsg", CallingConvention = CallingConvention.StdCall)]
        private static int EventGroupMsg(int subType, int msgId, long fromGroup, long fromQQ, string fromAnonymous, string msg, int font)
        {
            RobbotManager.Instance.Container.Resolve<IGroupMsgEvent>().Handle(new GroupMsgContext()
            {
                subType = subType,
                msgId = msgId,
                fromGroup = fromGroup,
                fromQQ = fromQQ,
                fromAnonymous = fromAnonymous,
                msg = msg,
                font = font
            });
            return 0;
        }

        [DllExport(ExportName = "_eventDiscussMsg", CallingConvention = CallingConvention.StdCall)]
        private static int EventDiscussMsg(int subType, int msgId, long fromDiscuss, long fromQQ, string msg, int font)
        {
            return 0;
        }

        [DllExport(ExportName = "_eventGroupUpload", CallingConvention = CallingConvention.StdCall)]
        private static int EventGroupUpload(int subType, int sendTime, long fromGroup, long fromQQ, string file)
        {
            return 0;
        }

        [DllExport(ExportName = "_eventSystem_GroupAdmin", CallingConvention = CallingConvention.StdCall)]
        private static int EventSystemGroupAdmin(int subType, int sendTime, long fromGroup, long beingOperateQQ)
        {
            return 0;
        }

        [DllExport(ExportName = "_eventSystem_GroupMemberDecrease", CallingConvention = CallingConvention.StdCall)]
        private static int EventSystemGroupMemberDecrease(int subType, int sendTime, long fromGroup, long fromQQ, long beingOperateQQ)
        {
            return 0;
        }

        [DllExport(ExportName = "_eventSystem_GroupMemberIncrease", CallingConvention = CallingConvention.StdCall)]
        private static int EventSystemGroupMemberIncrease(int subType, int sendTime, long fromGroup, long fromQQ, long beingOperateQQ)
        {
            return 0;
        }

        [DllExport(ExportName = "_eventFriend_Add", CallingConvention = CallingConvention.StdCall)]
        private static int EventFriendAdd(int subType, int sendTime, long fromQQ)
        {
            return 0;
        }

        [DllExport(ExportName = "_eventRequest_AddFriend", CallingConvention = CallingConvention.StdCall)]
        private static int EventRequestAddFriend(int subType, int sendTime, long fromQQ, string msg, string responseFlag)
        {
            return 0;
        }

        [DllExport(ExportName = "_eventRequest_AddGroup", CallingConvention = CallingConvention.StdCall)]
        private static int EventRequestAddGroup(int subType, int sendTime, long fromGroup, long fromQQ, string msg, string responseFlag)
        {
            return 0;
        }
    }
}
