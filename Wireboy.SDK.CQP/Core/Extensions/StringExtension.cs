using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wireboy.SDK.CQP.Core.Enums;

namespace Wireboy.SDK.CQP
{
    public static class StringExtension
    {
        /// <summary>
        /// @QQ号
        /// </summary>
        /// <param name="str"></param>
        /// <param name="qq">目标QQ</param>
        /// <returns></returns>
        public static string AtQQ(this string str, long qq)
        {
            return string.Format("{0}[CQ:at,qq={1}]", str, qq);
        }
        /// <summary>
        /// @全体成员（用于QQ群，需要管理员权限）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string AtAll(this string str)
        {
            return string.Format("{0}[CQ:at,qq=all]", str);
        }
        /// <summary>
        /// 添加经典表情
        /// </summary>
        /// <param name="str"></param>
        /// <param name="face">目标表情</param>
        /// <returns></returns>
        public static string AddFace(this string str, Face face)
        {
            return string.Format("{0}[CQ:face,id={1}]", str, face);
        }
        /// <summary>
        /// 添加Emoji表情
        /// </summary>
        /// <param name="str"></param>
        /// <param name="emoji">目标表情</param>
        /// <returns></returns>
        public static string AddEmoji(this string str,Emoji emoji)
        {
            return string.Format("{0}[CQ:emoji,id={1}]", str, emoji);
        }
        /// <summary>
        /// 戳一戳
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string AddShake(this string str)
        {
            return string.Format("{0}[CQ:shake]", str);
        }
        /// <summary>
        /// 消息换行
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string AddNewLine(this string str)
        {
            return string.Format("{0}{1}", str,Environment.NewLine);
        }
        /// <summary>
        /// 添加要发送的消息
        /// </summary>
        /// <param name="str"></param>
        /// <param name="msg">消息内容</param>
        /// <returns></returns>
        public static string AddMsg(this string str, string msg)
        {
            return str + msg;
        }
        /// <summary>
        /// 添加图片
        /// </summary>
        /// <param name="str"></param>
        /// <param name="imgPath">图片路径</param>
        /// <returns></returns>
        public static string AddImage(this string str, string imgPath)
        {
            var newName = Guid.NewGuid() + "." + Path.GetExtension(imgPath);
            if (!imgPath.StartsWith(CQ.GetImageDir()))
            {
                var destFileName = Path.Combine(CQ.GetImageDir(), newName);
                File.Copy(imgPath, destFileName, true);
            }
            return string.Format("{0}[CQ:image,file={1}]", str,newName);
        }
        /// <summary>
        /// 添加语音
        /// </summary>
        /// <param name="str"></param>
        /// <param name="recordPath">语音文件路径</param>
        /// <returns></returns>
        public static string AddRecord(this string str, string recordPath)
        {
            var newName = Guid.NewGuid() + "." + Path.GetExtension(recordPath);
            if (!recordPath.StartsWith(CQ.GetRecordDir()))
            {
                var destFileName = Path.Combine(CQ.GetRecordDir(), newName);
                File.Copy(recordPath, destFileName, true);
            }
            return string.Format("{0}[CQ:record,file={1},magic=false]", str, newName);
        }
        /// <summary>
        /// 发送QQ群消息
        /// </summary>
        /// <param name="str"></param>
        /// <param name="groupId">目标QQ群</param>
        public static void SendGroupMsg(this string str, long groupId)
        {
            CQ.SendGroupMsg(groupId, str);
        }
        /// <summary>
        /// 发送QQ群匿名消息
        /// </summary>
        /// <param name="str"></param>
        /// <param name="groupId">目标QQ群</param>
        public static void SendGroupAnonymousMsg(this string str, long groupId)
        {
            CQ.SendGroupMsg(groupId, str);
        }
        /// <summary>
        /// 发送好友消息
        /// </summary>
        /// <param name="str"></param>
        /// <param name="qqId">目标QQ</param>
        public static void SendPrivateMsg(this string str, long qqId)
        {
            CQ.SendPrivateMsg(qqId, str);
        }
        /// <summary>
        /// 发送讨论组消息
        /// </summary>
        /// <param name="str"></param>
        /// <param name="discussId">目标讨论组</param>
        public static void SendDiscussMsg(this string str, long discussId)
        {
            CQ.SendDiscussMsg(discussId, str);
        }
    }
}
