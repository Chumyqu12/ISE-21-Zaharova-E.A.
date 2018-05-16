using System.Runtime.Serialization;

namespace SoftwareDevelopmentService.ViewModels
{
    [DataContract]
    public class SoftwarePartViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int SoftwareId { get; set; }
        [DataMember]
        public int PartId { get; set; }
        [DataMember]
        public string PartName { get; set; }
        [DataMember]
        public int Number { get; set; }
    }
}
