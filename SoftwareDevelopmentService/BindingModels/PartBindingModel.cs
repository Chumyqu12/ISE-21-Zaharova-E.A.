using System.Runtime.Serialization;

namespace SoftwareDevelopmentService.BindingModels
{
    [DataContract]
    public class PartBindingModel
    {
        [DataMember]

        public int Id { get; set; }

        [DataMember]

        public string PartName { get; set; }
    }
}
