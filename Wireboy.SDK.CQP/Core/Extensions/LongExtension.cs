using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wireboy.SDK.CQP
{
    public static class LongExtension
    {
        /// <summary>
        /// 发送私聊
        /// </summary>
        /// <param name="qq"></param>
        /// <param name="msg">消息内容</param>
        public static void SendPrivateMsg(this long qq, string msg)
        {
            CQ.SendPrivateMsg(qq, msg);
        }
        /// <summary>
        /// 发送群消息
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="msg">消息内容</param>
        public static void SendGroupMsg(this long groupId, string msg)
        {
            CQ.SendGroupMsg(groupId, msg);
        }
        /// <summary>
        /// 发送讨论组消息
        /// </summary>
        /// <param name="sendDiscussId"></param>
        /// <param name="msg">消息内容</param>
        public static void SendDiscussMsg(this long sendDiscussId, string msg)
        {
            CQ.SendDiscussMsg(sendDiscussId, msg);
        }
    }
}
