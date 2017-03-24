using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using ZzaDashboard.Services;

namespace ZzaDashboard
{
    public static class ContainerHelper
    {
        public static IUnityContainer Container { get; }

        static ContainerHelper()
        {
            Container = new UnityContainer();
            Container.RegisterType<ICustomersRepository, CustomersRepository>(
                new ContainerControlledLifetimeManager());
        }
    }
}
