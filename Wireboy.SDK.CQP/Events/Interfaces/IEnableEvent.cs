using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wireboy.SDK.CQP.Events
{
    [Description("酷Q事件:Type=1003 应用已被启用")]
    public interface IEnableEvent : IWireboyEvent
    {
        void Handle(EnableContext context);
    }

    public class EnableContext
    {
    }
}
