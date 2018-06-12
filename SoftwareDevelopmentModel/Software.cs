using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftwareDevelopmentModel
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    public class Software
    {
        public int Id { get; set; }
        [Required]
        public string SoftwareName { get; set; }
        [Required]
        public decimal Cost { get; set; }
        [ForeignKey("SoftwareId")]
        public virtual List<Offer> Offers { get; set; }

        [ForeignKey("SoftwareId")]
        public virtual List<SoftwarePart> SoftwareParts { get; set; }
    }
}
