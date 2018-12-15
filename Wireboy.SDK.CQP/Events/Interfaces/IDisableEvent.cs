using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wireboy.SDK.CQP.Events
{
    [Description("酷Q事件:Type=1004 应用将被停用")]
    public interface IDisableEvent : IWireboyEvent
    {
        void Handle(DisableContext context);
    }

    public class DisableContext
    {
    }
}
