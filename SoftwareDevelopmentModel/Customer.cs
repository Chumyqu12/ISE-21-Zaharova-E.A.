using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftwareDevelopmentModel
{
    /// <summary>
    /// Клиент магазина
    /// </summary>
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string CustomerName { get; set; }

        public string Mail { get; set; }

        [ForeignKey("CustomerId")]
        public virtual List<Offer> Offers { get; set; }
       
    }
}
