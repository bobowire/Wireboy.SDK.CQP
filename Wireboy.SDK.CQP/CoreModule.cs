using Autofac;
using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wireboy.SDK.CQP.Events;

namespace Wireboy.SDK.CQP
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            LoadEvents(builder);
            LoadUtils(builder);
        }
        private void LoadEvents(ContainerBuilder builder)
        {
            builder.RegisterType<GroupMsgEvent>().As<IGroupMsgEvent>().InstancePerLifetimeScope();
            builder.RegisterType<RequestAddGroupEvent>().As<IRequestAddGroupEvent>().InstancePerLifetimeScope();
            builder.RegisterType<PrivateMsgEvent>().As<IPrivateMsgEvent>().InstancePerLifetimeScope();
        }

        private void LoadUtils(ContainerBuilder builder)
        {
            builder.RegisterType<Logger>().As<ILogger>().SingleInstance();
        }
    }
}
