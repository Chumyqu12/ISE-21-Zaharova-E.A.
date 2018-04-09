namespace SoftwareDevelopmentModel
{
    /// <summary>
    /// Сколько компонентов, требуется при изготовлении изделия
    /// </summary>
    public class SoftwarePart
    {
        public int Id { get; set; }

        public int SoftwareId { get; set; }

        public int PartId { get; set; }

        public int Number { get; set; }
    }
}
