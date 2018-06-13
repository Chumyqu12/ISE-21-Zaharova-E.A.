using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SoftwareDevelopmentService.ViewModels
{
    [DataContract]
    public class CustomerViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Mail { get; set; }

        [DataMember]
        public string CustomerName { get; set; }

        [DataMember]
        public List <MessageInfoViewModel>  Messages { get; set; }
    }
}
