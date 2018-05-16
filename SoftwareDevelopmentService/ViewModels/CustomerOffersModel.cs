using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDevelopmentService.ViewModels
{
    [DataContract]
    public class CustomerOffersModel
	{
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public string Creation { get; set; }
        [DataMember]
        public string SoftwareName { get; set; }
        [DataMember]
        public int Number { get; set; }
        [DataMember]
        public decimal Summa { get; set; }
        [DataMember]
        public string Condition { get; set; }
	}
}
