using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wireboy.SDK.CQP.SdkEvents
{
    [Description("酷Q事件: Initialize")]
    public interface IInitializeEvent : IWireboyEvent
    {
        void Handle(InitializeContext context);
    }

    public class InitializeContext
    {
    }
}
