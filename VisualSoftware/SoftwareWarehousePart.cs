using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualSoftware
{
    public class SoftwareWarehousePart
    {
        public int Id { get; set; }

        public int SoftwareWarehouseId { get; set; }

        public int PartId { get; set; }

        public int Count { get; set; }

    }
}
