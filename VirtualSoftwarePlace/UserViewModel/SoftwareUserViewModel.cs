using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualSoftwarePlace.UserViewModel
{
    public class SoftwareUserViewModel
    {
        public int Id { get; set; }

        public string SoftwareName { get; set; }

        public decimal Price { get; set; }

        public List<SoftwarePartUserViewModel> SoftwarePart { get; set; }
    }
}
