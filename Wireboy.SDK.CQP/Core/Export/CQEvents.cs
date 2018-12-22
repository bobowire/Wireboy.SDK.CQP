using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Wireboy.SDK.CQP.Events;
using Wireboy.SDK.CQP.Models;
using Wireboy.SDK.CQP.Events.Enums;

namespace Wireboy.SDK.CQP.Core
{
    public class CQEvents
    {
        /// <summary>
        /// 酷Q事件: AppInfo
        /// </summary>
        /// <returns></returns>
        [DllExport(ExportName = "AppInfo", CallingConvention = CallingConvention.StdCall)]
        private static string AppInfo()
        {
            return string.Format("{0},{1}", AppInfo_Const.AppVersion, AppInfo_Const.AppId);
        }

        /// <summary>
        /// 酷Q事件：OpenConsole
        /// </summary>
        /// <returns></returns>
        [DllExport(ExportName = "_eventOpenConsole", CallingConvention = CallingConvention.StdCall)]
        private static int EventOpenConsole()
        {
            RobbotManager.Resolve<IOpenConsoleEvent>()?.Handle(new OpenConsoleContext());
            return 0;
        }

        /// <summary>
        /// 酷Q事件: Initialize
        /// </summary>
        /// <param name="authCode">权限码</param>
        /// <returns></returns>
        [DllExport(ExportName = "Initialize", CallingConvention = CallingConvention.StdCall)]
        private static int Initialize(int authCode)
        {
            RobbotManager.AuthCode = authCode;
            RobbotManager.Resolve<IInitializeEvent>()?.Handle(new InitializeContext());
            return 0;
        }
        /// <summary>
        /// 酷Q事件: Type=1001 酷Q启动
        /// </summary>
        /// <returns></returns>
        [DllExport(ExportName = "_eventStartup", CallingConvention = CallingConvention.StdCall)]
        private static int EventStartUp()
        {
            RobbotManager.Resolve<IStartupEvent>()?.Handle(new StartupContext());
            return 0;
        }
        /// <summary>
        /// 酷Q事件:Type=1002 酷Q退出
        /// </summary>
        /// <returns></returns>
        [DllExport(ExportName = "_eventExit", CallingConvention = CallingConvention.StdCall)]
        private static int EventExit()
        {
            RobbotManager.Resolve<IExitEvent>()?.Handle(new ExitContext());
            return 0;
        }
        /// <summary>
        /// 酷Q事件:Type=1003 应用已被启用
        /// </summary>
        /// <returns></returns>
        [DllExport(ExportName = "_eventEnable", CallingConvention = CallingConvention.StdCall)]
        private static int EventEnable()
        {
            RobbotManager.Resolve<IEnableEvent>()?.Handle(new EnableContext());
            return 0;
        }
        /// <summary>
        /// 酷Q事件:Type=1004 应用将被停用
        /// </summary>
        /// <returns></returns>
        [DllExport(ExportName = "_eventDisable", CallingConvention = CallingConvention.StdCall)]
        private static int EventDisable()
        {
            RobbotManager.Resolve<IDisableEvent>()?.Handle(new DisableContext());
            return 0;
        }
        /// <summary>
        /// 酷Q事件:Type=21 私聊消息 - 好友
        /// </summary>
        /// <param name="subType">类型</param>
        /// <param name="msgId">消息Id</param>
        /// <param name="fromQQ">来源QQ</param>
        /// <param name="msg">消息内容</param>
        /// <param name="font">字体</param>
        /// <returns></returns>
        [DllExport(ExportName = "_eventPrivateMsg", CallingConvention = CallingConvention.StdCall)]
        private static int EventPrivateMsg(int subType, int msgId, long fromQQ, string msg, int font)
        {
            RobbotManager.Resolve<IPrivateMsgEvent>()?.Handle(new PrivateMsgContext()
            {
                subType = (Enum.IsDefined(typeof(PrivateMessageType), subType) ? (PrivateMessageType)subType : PrivateMessageType.Unknown),
                msgId = msgId,
                fromQQ = fromQQ,
                msg = msg,
                font = font
            });
            return 0;
        }
        /// <summary>
        /// 酷Q事件:Type=2 群消息
        /// </summary>
        /// <param name="subType">消息类型</param>
        /// <param name="msgId">消息Id</param>
        /// <param name="fromGroup">来源群</param>
        /// <param name="fromQQ">来源QQ</param>
        /// <param name="fromAnonymous">匿名信息</param>
        /// <param name="msg">消息内容</param>
        /// <param name="font">字体</param>
        /// <returns></returns>
        [DllExport(ExportName = "_eventGroupMsg", CallingConvention = CallingConvention.StdCall)]
        private static int EventGroupMsg(int subType, int msgId, long fromGroup, long fromQQ, string fromAnonymous, string msg, int font)
        {
            RobbotManager.Resolve<IGroupMsgEvent>()?.Handle(new GroupMsgContext()
            {
                subType = (Enum.IsDefined(typeof(GroupMessageType), subType) ? (GroupMessageType)subType : GroupMessageType.Unknown),
                msgId = msgId,
                fromGroup = fromGroup,
                fromQQ = fromQQ,
                fromAnonymous = fromAnonymous,
                msg = msg,
                font = font
            });
            return 0;
        }
        /// <summary>
        /// 酷Q事件:Type=4 讨论组消息
        /// </summary>
        /// <param name="subType">类型</param>
        /// <param name="msgId">消息Id</param>
        /// <param name="fromDiscuss">来源讨论组</param>
        /// <param name="fromQQ">来源QQ</param>
        /// <param name="msg">消息内容</param>
        /// <param name="font">字体</param>
        /// <returns></returns>
        [DllExport(ExportName = "_eventDiscussMsg", CallingConvention = CallingConvention.StdCall)]
        private static int EventDiscussMsg(int subType, int msgId, long fromDiscuss, long fromQQ, string msg, int font)
        {
            RobbotManager.Resolve<IDiscussMsgEvent>()?.Handle(new DiscussMsgContext()
            {
                subType = (Enum.IsDefined(typeof(DiscussMessageType), subType) ? (DiscussMessageType)subType : DiscussMessageType.Unknown),
                msgId = msgId,
                fromDiscuss = fromDiscuss,
                fromQQ = fromQQ,
                msg = msg,
                font = font
            });
            return 0;
        }
        /// <summary>
        /// 酷Q事件:Type=11 群文件上传事件
        /// </summary>
        /// <param name="subType">类型</param>
        /// <param name="sendTime">上传时间</param>
        /// <param name="fromGroup">来源群</param>
        /// <param name="fromQQ">来源QQ</param>
        /// <param name="file">文件信息</param>
        /// <returns></returns>
        [DllExport(ExportName = "_eventGroupUpload", CallingConvention = CallingConvention.StdCall)]
        private static int EventGroupUpload(int subType, int sendTime, long fromGroup, long fromQQ, string file)
        {
            RobbotManager.Resolve<IGroupUploadEvent>()?.Handle(new GroupUploadContext()
            {
                subType = subType,
                sendTime = sendTime,
                fromGroup = fromGroup,
                fromQQ = fromQQ,
                file = file
            });
            return 0;
        }
        /// <summary>
        /// 酷Q事件:Type=101 群事件-管理员变动
        /// </summary>
        /// <param name="subType">类型</param>
        /// <param name="sendTime">时间</param>
        /// <param name="fromGroup">来源群</param>
        /// <param name="beingOperateQQ">被操作QQ</param>
        /// <returns></returns>
        [DllExport(ExportName = "_eventSystem_GroupAdmin", CallingConvention = CallingConvention.StdCall)]
        private static int EventSystemGroupAdmin(int subType, int sendTime, long fromGroup, long beingOperateQQ)
        {
            RobbotManager.Resolve<IGroupAdminEvent>()?.Handle(new GroupAdminContext()
            {
                subType = (Enum.IsDefined(typeof(GroupAdminType), subType) ? (GroupAdminType)subType : GroupAdminType.Unknown),
                sendTime = sendTime,
                fromGroup = fromGroup,
                beingOperateQQ = beingOperateQQ
            });
            return 0;
        }
        /// <summary>
        /// 酷Q事件:Type=102 群事件-群成员减少
        /// </summary>
        /// <param name="subType">离开原因</param>
        /// <param name="sendTime">时间</param>
        /// <param name="fromGroup">来源群</param>
        /// <param name="fromQQ">操作者QQ</param>
        /// <param name="beingOperateQQ">离开者QQ</param>
        /// <returns></returns>
        [DllExport(ExportName = "_eventSystem_GroupMemberDecrease", CallingConvention = CallingConvention.StdCall)]
        private static int EventSystemGroupMemberDecrease(int subType, int sendTime, long fromGroup, long fromQQ, long beingOperateQQ)
        {
            RobbotManager.Resolve<IGroupMemberDecreaseEvent>()?.Handle(new GroupMemberDecreaseContext()
            {
                subType = (Enum.IsDefined(typeof(GroupMemberDecreaseType), subType) ? (GroupMemberDecreaseType)subType : GroupMemberDecreaseType.Unknow),
                sendTime = sendTime,
                fromGroup = fromGroup,
                fromQQ = fromQQ,
                beingOperateQQ = beingOperateQQ
            });
            return 0;
        }
        /// <summary>
        /// 酷Q事件:Type=103 群事件-群成员增加
        /// </summary>
        /// <param name="subType">加群途径</param>
        /// <param name="sendTime">时间</param>
        /// <param name="fromGroup">来源群</param>
        /// <param name="fromQQ">操作者QQ</param>
        /// <param name="beingOperateQQ">新成员QQ</param>
        /// <returns></returns>
        [DllExport(ExportName = "_eventSystem_GroupMemberIncrease", CallingConvention = CallingConvention.StdCall)]
        private static int EventSystemGroupMemberIncrease(int subType, int sendTime, long fromGroup, long fromQQ, long beingOperateQQ)
        {
            RobbotManager.Resolve<IGroupMemberIncreaseEvent>()?.Handle(new GroupMemberIncreaseContext()
            {
                subType = (Enum.IsDefined(typeof(GroupMemberIncreasedType), subType) ? (GroupMemberIncreasedType)subType : GroupMemberIncreasedType.Unknow),
                sendTime = sendTime,
                fromGroup = fromGroup,
                fromQQ = fromQQ,
                beingOperateQQ = beingOperateQQ
            });
            return 0;
        }
        /// <summary>
        /// 酷Q事件:Type=201 好友已添加
        /// </summary>
        /// <param name="subType">类型</param>
        /// <param name="sendTime">时间</param>
        /// <param name="fromQQ">来源QQ</param>
        /// <returns></returns>
        [DllExport(ExportName = "_eventFriend_Add", CallingConvention = CallingConvention.StdCall)]
        private static int EventFriendAdd(int subType, int sendTime, long fromQQ)
        {
            RobbotManager.Resolve<IFriendAddEvent>()?.Handle(new FriendAddContext()
            {
                subType = (Enum.IsDefined(typeof(FriendAddType), subType) ? (FriendAddType)subType : FriendAddType.Unknow),
                sendTime = sendTime,
                fromQQ = fromQQ
            });
            return 0;
        }
        /// <summary>
        /// 酷Q事件:Type=301 请求-好友添加
        /// </summary>
        /// <param name="subType">类型</param>
        /// <param name="sendTime">时间</param>
        /// <param name="fromQQ">来源QQ</param>
        /// <param name="msg">验证消息内容</param>
        /// <param name="responseFlag">反馈标识（用于处理请求）</param>
        /// <returns></returns>
        [DllExport(ExportName = "_eventRequest_AddFriend", CallingConvention = CallingConvention.StdCall)]
        private static int EventRequestAddFriend(int subType, int sendTime, long fromQQ, string msg, string responseFlag)
        {
            RobbotManager.Resolve<IRequestAddFriendEvent>()?.Handle(new RequestAddFriendContext()
            {
                subType = (Enum.IsDefined(typeof(RequestFriendAddType), subType) ? (RequestFriendAddType)subType : RequestFriendAddType.Unknow),
                sendTime = sendTime,
                fromQQ = fromQQ,
                msg = msg,
                responseFlag = responseFlag
            });
            return 0;
        }
        /// <summary>
        /// 酷Q事件:Type=302 请求-群添加
        /// </summary>
        /// <param name="subType">类型</param>
        /// <param name="sendTime">时间</param>
        /// <param name="fromGroup">来源群</param>
        /// <param name="fromQQ">来源QQ</param>
        /// <param name="msg">验证消息内容</param>
        /// <param name="responseFlag">反馈标识（用于处理请求）</param>
        /// <returns></returns>
        [DllExport(ExportName = "_eventRequest_AddGroup", CallingConvention = CallingConvention.StdCall)]
        private static int EventRequestAddGroup(int subType, int sendTime, long fromGroup, long fromQQ, string msg, string responseFlag)
        {
            RobbotManager.Resolve<IRequestAddGroupEvent>()?.Handle(new RequestAddGroupContext()
            {
                subType = (Enum.IsDefined(typeof(RequestGroupAddType), subType) ? (RequestGroupAddType)subType : RequestGroupAddType.Unknow),
                sendTime = sendTime,
                fromGroup = fromGroup,
                fromQQ = fromQQ,
                msg = msg,
                responseFlag = responseFlag
            });
            return 0;
        }
    }
}
