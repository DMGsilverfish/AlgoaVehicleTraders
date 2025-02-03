using System.ComponentModel.DataAnnotations;

namespace AlgoaVehicleTraders.Models.All
{
    public class CompanyDetails
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string CompanyEmail { get; set; }

        public string? CompanyPhone { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string LocationLink { get; set; }

        public string? VATNumber { get; set; }

        public string? AccountNumber { get; set; }

        public string? FacebookLink { get; set; }

        public string? InstagramLink { get; set; }

        [Required]
        public string DeveloperEmail { get; set; }

    }
}
