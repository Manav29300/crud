namespace GeneralCRUD.Models
{
    public class WarrantyConfiguration
    {
        public int WarrantyConfigId { get; set; }
        public int? ProductId { get; set; }
        public TimeSpan WarrantyDuration { get; set; }
        public string WarrantyType { get; set; }
        public string Coverage { get; set; }
        public string Conditions { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
