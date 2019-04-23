using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wireboy.SDK.CQP.SdkEvents
{
    [Description("酷Q事件: Type=1001 酷Q启动")]
    public interface IStartupEvent : IWireboyEvent
    {
        void Handle(StartupContext context);
    }

    public class StartupContext
    {
    }
}
