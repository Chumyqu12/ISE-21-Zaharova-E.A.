using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftwareDevelopmentModel
{
    /// <summary>
    /// Исполнитель, выполняющий заказы клиентов
    /// </summary>
    public class Developer
    {
        public int Id { get; set; }
        [Required]
        public string DeveloperName { get; set; }
        [ForeignKey("DeveloperId")]
        public virtual List<Offer> Offers { get; set; }
    }
}
