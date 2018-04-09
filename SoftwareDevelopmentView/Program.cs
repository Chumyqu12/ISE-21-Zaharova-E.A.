using SoftwareDevelopmentService;
using SoftwareDevelopmentService.Interfaces;
using SoftwareDevelopmentService.ImplementationsBD;
using SoftwareDevelopmentService.ImplementationsList;
using System;
using System.Data.Entity;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace SoftwareDevelopmentView
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
            currentContainer.RegisterType<DbContext, SoftwareDbContext>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICustomerService, CustomerServiceBD>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPartService, PartServiceBD>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IDeveloperService, DeveloperServiceBD>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ISoftwareService, SoftwareServiceBD>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IWarehouseService, WarehouseServiceBD>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IGeneralService, GeneralServiceBD>(new HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}
