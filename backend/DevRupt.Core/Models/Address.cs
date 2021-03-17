using System.ComponentModel.DataAnnotations;

namespace DevRupt.Core.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        
        public string AddressLine { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string CountryCode { get; set; }
    }
}