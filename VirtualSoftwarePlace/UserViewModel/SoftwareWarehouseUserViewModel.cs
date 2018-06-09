using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualSoftwarePlace.UserViewModel
{
    public class SoftwareWarehouseUserViewModel
    {
        public int Id { get; set; }

        public string SoftwareWarehouseName { get; set; }

        public List<SoftwareWarehousePartViewModel> SoftwareWarehouseParts { get; set; }
    }
}
