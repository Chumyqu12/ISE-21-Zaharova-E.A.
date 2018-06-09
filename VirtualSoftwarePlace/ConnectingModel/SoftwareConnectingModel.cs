using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualSoftwarePlace.ConnectingModel
{
    public class SoftwareConnectingModel
    {
        public int Id { get; set; }

        public string SoftwareName { get; set; }

        public decimal Value { get; set; }

        public List<SoftwarePartConnectingModel> SoftwarePart { get; set; }
    }
}
