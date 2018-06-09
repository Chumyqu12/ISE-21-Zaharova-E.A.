using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualSoftwarePlace.UserViewModel
{
    public class CustomerSelectionUserViewModel
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string CustomerFIO { get; set; }

        public int SoftwareId { get; set; }

        public string SoftwareName { get; set; }

        public int? DeveloperId { get; set; }

        public string DeveloperName { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }

        public string Status { get; set; }

        public string DateCreate { get; set; }

        public string DateCook { get; set; }
    }
}
