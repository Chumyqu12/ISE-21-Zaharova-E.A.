using System;

namespace SoftwareDevelopmentModel
{
    /// <summary>
    /// Заказ клиента
    /// </summary>
    public class Offer
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int SoftwareId { get; set; }

        public int? DeveloperId { get; set; }

        public int Number { get; set; }

        public decimal Summa { get; set; }

        public OfferCondition Condition { get; set; }

        public DateTime Creation { get; set; }

        public DateTime? Implementation { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual Software Software { get; set; }

        public virtual Developer Developer { get; set; }
    }
}
