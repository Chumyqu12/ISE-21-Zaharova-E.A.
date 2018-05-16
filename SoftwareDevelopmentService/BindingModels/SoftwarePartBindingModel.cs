using System.Runtime.Serialization;

namespace SoftwareDevelopmentService.BindingModels
{
    [DataContract]
    public class SoftwarePartBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int SoftwareId { get; set; }
        [DataMember]
        public int PartId { get; set; }
        [DataMember]
        public int Number { get; set; }
    }
}
