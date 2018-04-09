using SoftwareDevelopmentService.ImplementationsList;
using SoftwareDevelopmentService.Interfaces;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace AbstractShopView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormGeneral>());
        }

        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<ICustomerService, CustomerServiceList>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPartService, ParttServiceList>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IDeveloperService, DeveloperServiceList>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ISoftwareService, SoftwareServiceList>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IWarehouseService, WarehouseServiceList>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IGeneralService, GeneralServiceList>(new HierarchicalLifetimeManager());
            
            return currentContainer;
        }
    }
}
