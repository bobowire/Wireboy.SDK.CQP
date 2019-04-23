using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Wireboy.SDK.CQP.Core.Export
{
    public class CQFuncs
    {
        private const  string dllName = "CQP.dll";

        [DllImport(dllName, EntryPoint = "CQ_sendPrivateMsg")]
        public static extern int CQ_sendPrivateMsg(int authCode, long qqId, string msg);

        [DllImport(dllName, EntryPoint = "CQ_sendGroupMsg")]
        public static extern int CQ_sendGroupMsg(int authCode, long groupId, string msg);

        [DllImport(dllName, EntryPoint = "CQ_sendDiscussMsg")]
        public static extern int CQ_sendDiscussMsg(int authCode, long discussId, string msg);

        [DllImport(dllName, EntryPoint = "CQ_deleteMsg")]
        public static extern int CQ_deleteMsg(int authCode, long msgId);

        [DllImport(dllName, EntryPoint = "CQ_sendLikeV2")]
        public static extern int CQ_sendLikeV2(int authCode, long qqId, int times);

        [DllImport(dllName, EntryPoint = "CQ_getCookies")]
        public static extern string CQ_getCookies(int authCode);

        [DllImport(dllName, EntryPoint = "CQ_getRecord")]
        public static extern string CQ_getRecord(int authCode, string file, string format);

        [DllImport(dllName, EntryPoint = "CQ_getCsrfToken")]
        public static extern int CQ_getCsrfToken(int authCode);

        [DllImport(dllName, EntryPoint = "CQ_getAppDirectory")]
        public static extern string CQ_getAppDirectory(int authCode);

        [DllImport(dllName, EntryPoint = "CQ_getLoginQQ")]
        public static extern long CQ_getLoginQQ(int authCode);

        [DllImport(dllName, EntryPoint = "CQ_getLoginNick")]
        public static extern string CQ_getLoginNick(int authCode);

        [DllImport(dllName, EntryPoint = "CQ_setGroupKick")]
        public static extern int CQ_setGroupKick(int authCode, long groupId, long qqId, bool refuses);

        [DllImport(dllName, EntryPoint = "CQ_setGroupBan")]
        public static extern int CQ_setGroupBan(int authCode, long groupId, long qqId, long time);

        [DllImport(dllName, EntryPoint = "CQ_setGroupAdmin")]
        public static extern int CQ_setGroupAdmin(int authCode, long groupId, long qqId, bool isSet);

        [DllImport(dllName, EntryPoint = "CQ_setGroupSpecialTitle")]
        public static extern int CQ_setGroupSpecialTitle(int authCode, long groupId, long qqId, string title, long durationTime);

        [DllImport(dllName, EntryPoint = "CQ_setGroupWholeBan")]
        public static extern int CQ_setGroupWholeBan(int authCode, long groupId, bool isOpen);

        [DllImport(dllName, EntryPoint = "CQ_setGroupAnonymousBan")]
        public static extern int CQ_setGroupAnonymousBan(int authCode, long groupId, string anonymous, long banTime);

        [DllImport(dllName, EntryPoint = "CQ_setGroupAnonymous")]
        public static extern int CQ_setGroupAnonymous(int authCode, long groupId, bool isOpen);

        [DllImport(dllName, EntryPoint = "CQ_setGroupCard")]
        public static extern int CQ_setGroupCard(int authCode, long groupId, long qqId, string newCard);

        [DllImport(dllName, EntryPoint = "CQ_setGroupLeave")]
        public static extern int CQ_setGroupLeave(int authCode, long groupId, bool isDisband);

        [DllImport(dllName, EntryPoint = "CQ_setDiscussLeave")]
        public static extern int CQ_setDiscussLeave(int authCode, long disscussId);

        [DllImport(dllName, EntryPoint = "CQ_setFriendAddRequest")]
        public static extern int CQ_setFriendAddRequest(int authCode, string identifying, int requestType, string appendMsg);

        [Obsolete("请使用: CQ_setGroupAddRequestV2")]
        [DllImport(dllName, EntryPoint = "CQ_setGroupAddRequest")]
        public static extern int CQ_setGroupAddRequest(int authCode, string identifying, int requestType, int responseType);

        [DllImport(dllName, EntryPoint = "CQ_setGroupAddRequestV2")]
        public static extern int CQ_setGroupAddRequestV2(int authCode, string identifying, int requestType, int responseType, string appendMsg);

        [DllImport(dllName, EntryPoint = "CQ_addLog")]
        public static extern int CQ_addLog(int authCode, int priority, string type, string Msg);

        [DllImport(dllName, EntryPoint = "CQ_setFatal")]
        public static extern int CQ_setFatal(int authCode, string errorMsg);

        [DllImport(dllName, EntryPoint = "CQ_getGroupMemberInfoV2")]
        public static extern string CQ_getGroupMemberInfoV2(int authCode, long groudId, long qqId, bool isCache);

        [DllImport(dllName, EntryPoint = "CQ_getGroupMemberList")]
        public static extern string CQ_getGroupMemberList(int authCode, long groupId);

        [DllImport(dllName, EntryPoint = "CQ_getGroupList")]
        public static extern string CQ_getGroupList(int authCode);

        [DllImport(dllName, EntryPoint = "CQ_getStrangerInfo")]
        public static extern string CQ_getStrangerInfo(int authCode, long qqId, bool notCache);
    }
}
