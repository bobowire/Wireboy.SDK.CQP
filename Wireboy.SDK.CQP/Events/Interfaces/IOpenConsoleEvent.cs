using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wireboy.SDK.CQP.Events
{
    [Description("酷Q事件:打开插件控制台事件")]
    public interface IOpenConsoleEvent : IWireboyEvent
    {
        void Handle(OpenConsoleContext context);
    }

    public class OpenConsoleContext
    {
    }
}
