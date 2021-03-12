namespace DevRupt.App.Models
{
    public class RatePlan
    {
        public string Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsSubjectToCityTax { get; set; }
    }
}