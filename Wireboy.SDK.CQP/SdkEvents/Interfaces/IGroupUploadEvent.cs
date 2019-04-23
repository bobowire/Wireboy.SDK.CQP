using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wireboy.SDK.CQP.SdkEvents
{
    [Description("酷Q事件:Type=11 群文件上传事件")]
    public interface IGroupUploadEvent : IWireboyEvent
    {
        void Handle(GroupUploadContext context);
    }

    public class GroupUploadContext
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        public int subType;
        /// <summary>
        /// 上传时间
        /// </summary>
        public int sendTime;
        /// <summary>
        /// 来源群
        /// </summary>
        public long fromGroup;
        /// <summary>
        /// 来源QQ
        /// </summary>
        public long fromQQ;
        /// <summary>
        /// 文件信息
        /// </summary>
        public string file;
    }
}
