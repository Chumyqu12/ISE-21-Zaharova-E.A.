using System.Runtime.Serialization;

namespace SoftwareDevelopmentService.BindingModels
{
    [DataContract]
    public class DeveloperBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string DeveloperName { get; set; }
    }
}
