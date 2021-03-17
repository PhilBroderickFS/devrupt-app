using System;
using System.ComponentModel.DataAnnotations;

namespace DevRupt.Core.Models
{
    public class PrimaryGuest
    {
        [Key] 
        public int Id { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public Address Address { get; set; }

        public string NationalityCountryCode { get; set; }

        public DateTimeOffset BirthDate{ get; set; }

        public string Gender { get; set; }

        public string BirthPlace { get; set; }

        public string PreferredLanguage { get; set; }
    }
}