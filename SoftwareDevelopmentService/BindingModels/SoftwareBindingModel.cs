using System.Collections.Generic;

namespace SoftwareDevelopmentService.BindingModels
{
    public class SoftwareBindingModel
    {
        public int Id { get; set; }

        public string SoftwareName { get; set; }

        public decimal Cost { get; set; }

        public List<SoftwarePartBindingModel> SoftwareParts { get; set; }
    }
}
