using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualSoftware
{
    public class CustomerSelection
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int SoftwareId { get; set; }

        public int? DeveloperId { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }

        public CustomerSelectionCondition Status { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime? DateImplement { get; set; }
    }
}
