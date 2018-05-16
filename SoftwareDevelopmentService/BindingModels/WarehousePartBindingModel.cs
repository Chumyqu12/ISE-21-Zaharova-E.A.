using System.Runtime.Serialization;

namespace SoftwareDevelopmentService.BindingModels
{
    [DataContract]
    public class WarehousePartBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int WarehouseId { get; set; }
        [DataMember]
        public int PartId { get; set; }
        [DataMember]
        public int Number { get; set; }
    }
}
