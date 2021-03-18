namespace DevRupt.Core.Models
{
    public class ServiceTotalAmount
    {
        public int Id { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal NetAmount { get; set; }
        public string Currency { get; set; }
    }
}