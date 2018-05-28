using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualSoftwarePlace.UserViewModel
{
    public class SoftwareWarehousePartViewModel
    {
        public int Id { get; set; }

        public int SoftwareWarehouseId { get; set; }

        public int PartId { get; set; }

        public string PartName { get; set; }

        public int Count { get; set; }
    }
}
