namespace SoftwareDevelopmentService.BindingModels
{
    public class OfferBindingModel
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int SoftwareId { get; set; }

        public int? DeveloperId { get; set; }

        public int Number { get; set; }

        public decimal Summa { get; set; }
    }
}
