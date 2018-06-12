using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftwareDevelopmentModel
{
    /// <summary>
    /// Компонент, требуемый для изготовления изделия
    /// </summary>
    public class Part
    {
        public int Id { get; set; }
        [Required]

        public string PartName { get; set; }

        [ForeignKey("PartId")]
        public virtual List<SoftwarePart> SoftwareParts { get; set; }

        [ForeignKey("PartId")]
        public virtual List<WarehousePart> WarehouseParts { get; set; }
    }
}
