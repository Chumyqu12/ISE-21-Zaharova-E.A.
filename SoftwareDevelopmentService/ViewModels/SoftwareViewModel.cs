using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SoftwareDevelopmentService.ViewModels
{
    [DataContract]
    public class SoftwareViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string SoftwareName { get; set; }
        [DataMember]
        public decimal Cost { get; set; }
        [DataMember]
        public List<SoftwarePartViewModel> SoftwareParts { get; set; }
    }
}
