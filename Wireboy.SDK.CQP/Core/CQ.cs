using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wireboy.SDK.CQP.Core.Export;
using Wireboy.SDK.CQP.Core.Enums;
using Wireboy.SDK.CQP.Core;
using Wireboy.SDK.CQP.Core.Models;

namespace Wireboy.SDK.CQP
{
    public static class CQ
    {
        /// <summary>
        /// 发送好友消息
        /// </summary>
        /// <param name="qqId">目标QQ</param>
        /// <param name="msg">消息内容</param>
        /// <returns></returns>
        public static int SendPrivateMsg(long qqId, string msg)
        {
            return CQFuncs.CQ_sendPrivateMsg(RobbotManager.AuthCode, qqId, msg);
        }
        /// <summary>
        /// 发送群消息
        /// </summary>
        /// <param name="groupId">目标群</param>
        /// <param name="msg">消息内容</param>
        /// <returns></returns>
        public static int SendGroupMsg(long groupId, string msg)
        {
            return CQFuncs.CQ_sendGroupMsg(RobbotManager.AuthCode, groupId, msg);
        }

        /// <summary>
        /// 发送讨论组消息
        /// </summary>
        /// <param name="discussId">目标讨论组</param>
        /// <param name="msg">消息内容</param>
        /// <returns></returns>
        public static int SendDiscussMsg(long discussId, string msg)
        {
            return CQFuncs.CQ_sendDiscussMsg(RobbotManager.AuthCode, discussId, msg);
        }
        /// <summary>
        /// 撤回消息
        /// </summary>
        /// <param name="msgId">消息ID</param>
        /// <returns></returns>
        public static int DeleteMsg(long msgId)
        {
            return CQFuncs.CQ_deleteMsg(RobbotManager.AuthCode, msgId);
        }
        /// <summary>
        /// 点赞
        /// </summary>
        /// <param name="qqId">目标QQ</param>
        /// <param name="times">赞的次数，最多10次</param>
        /// <returns></returns>
        public static int SendLikeV2(long qqId, int times)
        {
            return CQFuncs.CQ_sendLikeV2(RobbotManager.AuthCode, qqId, times);
        }
        /// <summary>
        /// 获取Cookie
        /// </summary>
        /// <returns></returns>
        public static string GetCookies()
        {
            return CQFuncs.CQ_getCookies(RobbotManager.AuthCode);
        }
        /// <summary>
        /// 接收语音
        /// </summary>
        /// <param name="file">收到消息中的语音文件名(file)</param>
        /// <param name="outformat">应用所需的格式</param>
        /// <returns></returns>
        public static string GetRecord(string file, string format)
        {
            return CQFuncs.CQ_getRecord(RobbotManager.AuthCode, file, format);
        }
        /// <summary>
        /// 取CsrfToken(慎用
        /// </summary>
        /// <returns></returns>
        public static int GetCsrfToken()
        {
            return CQFuncs.CQ_getCsrfToken(RobbotManager.AuthCode);
        }
        /// <summary>
        /// 取应用目录
        /// </summary>
        /// <returns></returns>
        public static string GetAppDirectory()
        {
            return CQFuncs.CQ_getAppDirectory(RobbotManager.AuthCode);
        }
        /// <summary>
        /// 取登录QQ
        /// </summary>
        /// <returns></returns>
        public static long GetLoginQQ()
        {
            return CQFuncs.CQ_getLoginQQ(RobbotManager.AuthCode);
        }
        /// <summary>
        /// 取登录昵称
        /// </summary>
        /// <returns></returns>
        public static string GetLoginNick()
        {
            return CQFuncs.CQ_getLoginNick(RobbotManager.AuthCode);
        }
        /// <summary>
        /// 置群员移除
        /// </summary>
        /// <param name="groupId">目标群</param>
        /// <param name="qqId">目标QQ</param>
        /// <param name="refuses">如果为真，则“不再接收此人加群申请”，请慎用</param>
        /// <returns></returns>
        public static int SetGroupKick(long groupId, long qqId, bool refuses)
        {
            return CQFuncs.CQ_setGroupKick(RobbotManager.AuthCode, groupId, qqId, refuses);
        }
        /// <summary>
        /// 置群员禁言
        /// </summary>
        /// <param name="groupId">目标群</param>
        /// <param name="qqId">目标QQ</param>
        /// <param name="time">禁言的时间，单位为秒。如果要解禁，这里填写0</param>
        /// <returns></returns>
        public static int SetGroupBan(long groupId, long qqId, long time)
        {
            return CQFuncs.CQ_setGroupBan(RobbotManager.AuthCode, groupId, qqId, time);
        }
        /// <summary>
        /// 置群管理员
        /// </summary>
        /// <param name="groupId">目标群</param>
        /// <param name="qqId">被设置的QQ</param>
        /// <param name="isSet">真/设置管理员 假/取消管理员</param>
        /// <returns></returns>
        public static int SetGroupAdmin(long groupId, long qqId, bool isSet)
        {
            return CQFuncs.CQ_setGroupAdmin(RobbotManager.AuthCode, groupId, qqId, isSet);
        }
        /// <summary>
        /// 置群成员专属头衔
        /// </summary>
        /// <param name="groupId">目标群</param>
        /// <param name="qqId">目标QQ</param>
        /// <param name="title">如果要删除，这里填空</param>
        /// <param name="durationTime">专属头衔有效期，单位为秒。如果永久有效，这里填写-1</param>
        /// <returns></returns>
        public static int SetGroupSpecialTitle(long groupId, long qqId, string title, long durationTime)
        {
            return CQFuncs.CQ_setGroupSpecialTitle(RobbotManager.AuthCode, groupId, qqId, title, durationTime);
        }
        /// <summary>
        /// 置全群禁言
        /// </summary>
        /// <param name="groupId">目标群</param>
        /// <param name="isOpen">真/开启 假/关闭</param>
        /// <returns></returns>
        public static int SetGroupWholeBan(long groupId, bool isOpen)
        {
            return CQFuncs.CQ_setGroupWholeBan(RobbotManager.AuthCode, groupId, isOpen);
        }
        /// <summary>
        /// 置匿名群员禁言
        /// </summary>
        /// <param name="groupId">目标群</param>
        /// <param name="anonymous">群消息事件收到的“匿名”参数</param>
        /// <param name="banTime">禁言的时间，单位为秒。不支持解禁</param>
        /// <returns></returns>
        public static int SetGroupAnonymousBan(long groupId, string anonymous, long banTime)
        {
            return CQFuncs.CQ_setGroupAnonymousBan(RobbotManager.AuthCode, groupId, anonymous, banTime);
        }
        /// <summary>
        /// 置群匿名设置
        /// </summary>
        /// <param name="groupId">目标群</param>
        /// <param name="isOpen">是否开启</param>
        /// <returns></returns>
        public static int SetGroupAnonymous(long groupId, bool isOpen)
        {
            return CQFuncs.CQ_setGroupAnonymous(RobbotManager.AuthCode, groupId, isOpen);
        }
        /// <summary>
        /// 置群成员名片
        /// </summary>
        /// <param name="groupId">目标群</param>
        /// <param name="qqId">被设置的QQ</param>
        /// <param name="newCard">新名片_昵称</param>
        /// <returns></returns>
        public static int SetGroupCard(long groupId, long qqId, string newCard)
        {
            return CQFuncs.CQ_setGroupCard(RobbotManager.AuthCode, groupId, qqId, newCard);
        }
        /// <summary>
        /// 置群退出
        /// </summary>
        /// <param name="groupId">目标群</param>
        /// <param name="isDisband">真/解散本群(群主) 假/退出本群(管理、群成员)</param>
        /// <returns></returns>
        public static int SetGroupLeave(long groupId, bool isDisband)
        {
            return CQFuncs.CQ_setGroupLeave(RobbotManager.AuthCode, groupId, isDisband);
        }
        /// <summary>
        /// 置讨论组退出
        /// </summary>
        /// <param name="disscussId">目标讨论组</param>
        /// <returns></returns>
        public static int SetDiscussLeave(long disscussId)
        {
            return CQFuncs.CQ_setDiscussLeave(RobbotManager.AuthCode, disscussId);
        }
        /// <summary>
        /// 置好友添加请求
        /// </summary>
        /// <param name="identifying">请求事件收到的“反馈标识”参数</param>
        /// <param name="requestType">#请求_通过 或 #请求_拒绝</param>
        /// <param name="appendMsg">添加后的好友备注</param>
        /// <returns></returns>
        public static int SetFriendAddRequest(string identifying, int requestType, string appendMsg)
        {
            return CQFuncs.CQ_setFriendAddRequest(RobbotManager.AuthCode, identifying, requestType,appendMsg);
        }

        /// <summary>
        /// 置群添加请求
        /// </summary>
        /// <param name="identifying">请求事件收到的“反馈标识”参数</param>
        /// <param name="requestType">根据请求事件的子类型区分 #请求_群添加 或 #请求_群邀请</param>
        /// <param name="responseType">#请求_通过 或 #请求_拒绝</param>
        /// <returns></returns>
        [Obsolete("请使用: CQ_setGroupAddRequestV2")]
        public static int SetGroupAddRequest(string identifying, int requestType, int responseType)
        {
            return CQFuncs.CQ_setGroupAddRequest(RobbotManager.AuthCode, identifying, requestType, responseType);
        }
        /// <summary>
        /// 置群添加请求
        /// </summary>
        /// <param name="identifying">请求事件收到的“反馈标识”参数</param>
        /// <param name="requestType">根据请求事件的子类型区分 #请求_群添加 或 #请求_群邀请</param>
        /// <param name="responseType">#请求_通过 或 #请求_拒绝</param>
        /// <param name="appendMsg">操作理由，仅 #请求_群添加 且 #请求_拒绝 时可用</param>
        /// <returns></returns>
        public static int SetGroupAddRequestV2(string identifying, int requestType, int responseType, string appendMsg)
        {
            return CQFuncs.CQ_setGroupAddRequestV2(RobbotManager.AuthCode, identifying, requestType, responseType, appendMsg);
        }
        /// <summary>
        /// 增加运行日志
        /// </summary>
        /// <param name="priority">优先级（#Log_ 开头常量）</param>
        /// <param name="type">类型（标题）</param>
        /// <param name="Msg">内容</param>
        /// <returns></returns>
        public static int AddLog(LogerLevel priority, string type, string Msg)
        {
            return CQFuncs.CQ_addLog(RobbotManager.AuthCode, (int)priority, type, Msg);
        }
        /// <summary>
        /// 置致命错误提示
        /// </summary>
        /// <param name="errorMsg">错误信息</param>
        /// <returns></returns>
        public static int SetFatal(string errorMsg)
        {
            return CQFuncs.CQ_setFatal(RobbotManager.AuthCode, errorMsg);
        }

        /// <summary>
        /// 取群成员信息(支持缓存)
        /// </summary>
        /// <param name="groudId">目标QQ所在群</param>
        /// <param name="qqId">目标QQ</param>
        /// <param name="isCache">不使用缓存</param>
        /// <returns></returns>
        public static GroupMemberInfo GetGroupMemberInfoV2(long groudId, long qqId, bool isCache)
        {
            string jsonData = CQFuncs.CQ_getGroupMemberInfoV2(RobbotManager.AuthCode, groudId, qqId, isCache);
            GroupMemberInfo groupMemberInfo = new GroupMemberInfo();
            JsonUtils utils = new JsonUtils(jsonData);
            utils.Resolve(groupMemberInfo);
            return groupMemberInfo;
        }

        /// <summary>
        /// 取群成员列表
        /// </summary>
        /// <param name="groupId">目标群</param>
        /// <returns></returns>
        public static List<GroupMemberInfo> GetGroupMemberList(long groupId)
        {
            List<GroupMemberInfo> memberList = new List<GroupMemberInfo>();
            string jsonData = CQFuncs.CQ_getGroupMemberList(RobbotManager.AuthCode, groupId);
            JsonUtils utils = new JsonUtils(jsonData);
            utils.ResolveList(memberList);
            return memberList;
        }

        /// <summary>
        /// 取群列表
        /// </summary>
        /// <returns></returns>
        public static string GetGroupList()
        {
            return CQFuncs.CQ_getGroupList(RobbotManager.AuthCode);
        }
        /// <summary>
        /// 取陌生人信息(支持缓存)
        /// </summary>
        /// <param name="qqId">目标QQ</param>
        /// <param name="notCache">是否不使用缓存</param>
        /// <returns></returns>
        public static StrangerInfo GetStrangerInfo(long qqId, bool notCache)
        {
            string jsonData = CQFuncs.CQ_getStrangerInfo(RobbotManager.AuthCode, qqId, notCache);
            StrangerInfo strangerInfo = new StrangerInfo();
            JsonUtils utils = new JsonUtils(jsonData);
            utils.Resolve(strangerInfo);
            return strangerInfo;
        }
    }
}

