using System.ComponentModel.DataAnnotations;

namespace EpsilonTest.Core
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        [Required]
        public string ContactName { get; set; }
		[Required]
		public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
		[Required]
		public string Phone { get; set; }
    }
}