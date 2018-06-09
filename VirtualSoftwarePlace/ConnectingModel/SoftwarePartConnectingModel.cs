using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualSoftwarePlace.ConnectingModel
{
    public class SoftwarePartConnectingModel
    {
        public int Id { get; set; }

        public int SoftwareId { get; set; }

        public int PartId { get; set; }

        public int Count { get; set; }
    }
}
