namespace DevRupt.Core.Models
{
    public class Service
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PricingUnit { get; set; }
        public GrossPrice DefaultGrossPrice { get; set; }
    }

    public class GrossPrice
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}