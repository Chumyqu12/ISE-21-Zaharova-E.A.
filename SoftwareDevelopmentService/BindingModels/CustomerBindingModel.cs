using System.Runtime.Serialization;

namespace SoftwareDevelopmentService.BindingModels
{
    [DataContract]
    public class CustomerBindingModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string CustomerName { get; set; }

    }
}
