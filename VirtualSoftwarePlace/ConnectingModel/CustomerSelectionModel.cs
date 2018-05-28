using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualSoftwarePlace.ConnectingModel
{
    public class CustomerSelectionModel
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int SoftwareId { get; set; }

        public int? DeveloperId { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }
    }
}
