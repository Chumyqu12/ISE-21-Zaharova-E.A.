using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualSoftwarePlace.ConnectingModel
{
    public class SoftwareWarehousePartConnectingModel
    {
        public int Id { get; set; }

        public int SoftwareWarehouseId { get; set; }

        public int PartId { get; set; }

        public int Count { get; set; }
    }
}
