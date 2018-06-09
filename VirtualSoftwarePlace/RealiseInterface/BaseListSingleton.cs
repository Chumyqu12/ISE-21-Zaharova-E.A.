using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualSoftwarePlace.ConnectingModel;
using VirtualSoftwarePlace.UserViewModel;
using VirtualSoftware;

namespace VirtualSoftwarePlace.RealiseInterface
{
    public class BaseListSingleton
    {
        private static BaseListSingleton instance;

        public List<Customer> Customers { get; set; }

        public List<Part> Parts { get; set; }

        public List<Developer> Developers { get; set; }

        public List<CustomerSelection> CustomerSelections { get; set; }

        public List<Software> Softwares { get; set; }

        public List<SoftwarePart> SoftwareParts { get; set; }

        public List<SoftwareWarehouse> SoftwareWarehouses { get; set; }

        public List<SoftwareWarehousePart> SoftwareWarehousePart { get; set; }

        private BaseListSingleton()
        {
            Customers = new List<Customer>();
            Parts = new List<Part>();
            Developers = new List<Developer>();
            CustomerSelections = new List<CustomerSelection>();
            Softwares = new List<Software>();
            SoftwareParts = new List<SoftwarePart>();
            SoftwareWarehouses = new List<SoftwareWarehouse>();
            SoftwareWarehousePart = new List<SoftwareWarehousePart>();
        }

        public static BaseListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new BaseListSingleton();
            }
            return instance;
        }
    }
}
