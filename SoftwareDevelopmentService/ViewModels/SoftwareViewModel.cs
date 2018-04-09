using System.Collections.Generic;

namespace SoftwareDevelopmentService.ViewModels
{
    public class SoftwareViewModel
    {
        public int Id { get; set; }

        public string SoftwareName { get; set; }

        public decimal Cost { get; set; }

        public List<SoftwarePartViewModel> SoftwareParts { get; set; }
    }
}
