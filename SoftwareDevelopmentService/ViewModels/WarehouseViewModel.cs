using System.Collections.Generic;

namespace SoftwareDevelopmentService.ViewModels
{
    public class WarehouseViewModel
    {
        public int Id { get; set; }

        public string WarehouseName { get; set; }

        public List<WarehousePartViewModel> WarehouseParts { get; set; }
    }
}
