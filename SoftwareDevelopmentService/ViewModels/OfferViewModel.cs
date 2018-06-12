namespace SoftwareDevelopmentService.ViewModels
{
    public class OfferViewModel
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public int SoftwareId { get; set; }

        public string SoftwareName { get; set; }

        public int? DeveloperId { get; set; }

        public string DeveloperName { get; set; }

        public int Number { get; set; }

        public decimal Summa { get; set; }

        public string Condition { get; set; }

        public string Creation { get; set; }

        public string Implementation { get; set; }
    }
}
