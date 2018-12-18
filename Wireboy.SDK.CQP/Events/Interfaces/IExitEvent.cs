using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wireboy.SDK.CQP.Events
{
    [Description("酷Q事件:Type=1002 酷Q退出")]
    public interface IExitEvent : IWireboyEvent
    {
        void Handle(ExitContext context);
    }

    public class ExitContext
    {
    }
}
