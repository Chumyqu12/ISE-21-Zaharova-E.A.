using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDevelopmentService.ViewModels
{
    [DataContract]
    public class WarehousesLoadViewModel
	{
        [DataMember]

        public string WarehouseName { get; set; }

        [DataMember]

        public int TotalCount { get; set; }

        [DataMember]
        public List<WarehousesPartLoadViewModel> Parts { get; set; }
    }

    [DataContract]

    public class WarehousesPartLoadViewModel

    {
        [DataMember]
        public string PartName { get; set; }
    
        [DataMember]
        public int Number { get; set; }
}
}
