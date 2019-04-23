using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wireboy.SDK.CQP.SdkEvents.Enums;

namespace Wireboy.SDK.CQP.SdkEvents
{
    [Description("酷Q事件:Type=302 请求-群添加")]
    public interface IRequestAddGroupEvent : IWireboyEvent
    {
        void Handle(RequestAddGroupContext context);
    }

    public class RequestAddGroupContext
    {
        public RequestGroupAddType subType;
        public int sendTime;
        public long fromGroup;
        public long fromQQ;
        public string msg;
        public string responseFlag;
    }
}
