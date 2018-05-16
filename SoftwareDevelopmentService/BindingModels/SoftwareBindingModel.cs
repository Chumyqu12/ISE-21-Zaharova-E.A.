using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SoftwareDevelopmentService.BindingModels
{
    [DataContract]
    public class SoftwareBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string SoftwareName { get; set; }
        [DataMember]
        public decimal Cost { get; set; }
        [DataMember]
        public List<SoftwarePartBindingModel> SoftwareParts { get; set; }
    }
}
