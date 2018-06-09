using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;
using VirtualSoftwarePlace.ConnectingModel;
using VirtualSoftwarePlace.LogicInterface;
using VirtualSoftwarePlace.RealiseInterface;

namespace VirtualSoftwareView
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
            currentContainer.RegisterType<ICustomerCustomer, CustomerSelectionList>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPartService, PartSelectionList>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IDeveloperService, DeveloperSelectionList>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ISoftwareService, SoftwareSelectionList>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ISoftwareWarehouseService, SoftwareWarehouseSelectionList>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IGeneralSelection, GeneralSelectionList>(new HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}
