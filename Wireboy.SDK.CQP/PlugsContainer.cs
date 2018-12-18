using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wireboy.SDK.CQP
{
    public class PlugsContainer
    {
        public IContainer LoadPlugs()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterModule(new CoreModule());
            IContainer container = builder.Build(); 
            return container;
        }
    }
}
