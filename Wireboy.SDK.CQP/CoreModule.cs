using Autofac;
using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wireboy.SDK.CQP.SdkEvents;
using Wireboy.SDK.CQP.SdkModule.DataBase;
using Wireboy.SDK.CQP.SdkModule.Utils;

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
            AutoInjectInterface(builder);
        }

        private void AutoInjectInterface(ContainerBuilder builder)
        {
            Dictionary<string, List<string>> retList = new Dictionary<string, List<string>>();
            Type[] types = System.Reflection.Assembly.GetExecutingAssembly().GetTypes();
            Type[] iClassList = types.Where(t => typeof(IWireboyEvent).IsAssignableFrom(t)).ToArray();
            foreach (Type iClass in iClassList)
            {
                Type impl = types.Where(t => iClass.IsAssignableFrom(t)).FirstOrDefault();
                builder.RegisterType(impl).As(iClass).InstancePerLifetimeScope();
            }
        }

        private void LoadUtils(ContainerBuilder builder)
        {
            builder.RegisterType<SqlServerDb>().AsSelf().SingleInstance();
            builder.RegisterType<WireboyTimer>().AsSelf().SingleInstance();
        }
    }
}
