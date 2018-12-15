using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wireboy.SDK.CQP
{
    public static class RobbotManager
    {
        private static ManageerInstance _instance = null;
        private static object obj = new object();
        public static int AuthCode { set; get; }
        public static ManageerInstance Instance
        {
            set { _instance = value; }
            get
            {
                if(_instance == null)
                {
                    lock(obj)
                    {
                        if (_instance == null)
                        {
                            _instance = new ManageerInstance();
                        }
                    }
                }
                return _instance;
            }
        }
        public static T Resolve<T>()
        {
            if (Instance.Container.IsRegistered<T>())
                return Instance.Container.Resolve<T>();
            else
                return default(T);
        }

    }
    public class ManageerInstance
    {
        IContainer _container = null;
        public ManageerInstance()
        {
            PlugsContainer plugsContainer = new PlugsContainer();
            Container = plugsContainer.LoadPlugs();
        }

        public IContainer Container { get => _container; set => _container = value; }
    }
}
