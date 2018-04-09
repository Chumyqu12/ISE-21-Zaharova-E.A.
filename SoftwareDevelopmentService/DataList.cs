using SoftwareDevelopmentModel;
using System.Collections.Generic;

namespace SoftwareDevelopmentService
{
    class DataListSingleton
    {
        private static DataListSingleton instance;

        public List<Customer> Customers { get; set; }

        public List<Part> Parts { get; set; }

        public List<Developer> Developers { get; set; }

        public List<Offer> Offers { get; set; }

        public List<Software> Softwares { get; set; }

        public List<SoftwarePart> SoftwareParts { get; set; }

        public List<Warehouse> Warehouses { get; set; }

        public List<WarehousePart> WarehouseParts { get; set; }

        private DataListSingleton()
        {
            Customers = new List<Customer>();
            Parts = new List<Part>();
            Developers = new List<Developer>();
            Offers = new List<Offer>();
            Softwares = new List<Software>();
            SoftwareParts = new List<SoftwarePart>();
            Warehouses = new List<Warehouse>();
            WarehouseParts = new List<WarehousePart>();
        }

        public static DataListSingleton GetInstance()
        {
            if(instance == null)
            {
                instance = new DataListSingleton();
            }

            return instance;
        }
    }
}
