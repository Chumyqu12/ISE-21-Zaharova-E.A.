using System.Runtime.Serialization;

namespace SoftwareDevelopmentService.ViewModels
{
    [DataContract]
    public class OfferViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public int SoftwareId { get; set; }
        [DataMember]
        public string SoftwareName { get; set; }
        [DataMember]
        public int? DeveloperId { get; set; }
        [DataMember]
        public string DeveloperName { get; set; }
        [DataMember]
        public int Number { get; set; }
        [DataMember]
        public decimal Summa { get; set; }
        [DataMember]
        public string Condition { get; set; }
        [DataMember]
        public string Creation { get; set; }
        [DataMember]
        public string Implementation { get; set; }
    }
}
