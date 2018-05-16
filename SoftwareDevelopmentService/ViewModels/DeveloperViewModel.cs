using System.Runtime.Serialization;

namespace SoftwareDevelopmentService.ViewModels
{
    [DataContract]
    public class DeveloperViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string DeveloperName { get; set; }
    }
}
