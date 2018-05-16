using System.Runtime.Serialization;

namespace SoftwareDevelopmentService.ViewModels
{
    [DataContract]
    public class PartViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string PartName { get; set; }
    }
}
