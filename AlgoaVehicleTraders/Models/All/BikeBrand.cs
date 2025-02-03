using System.ComponentModel.DataAnnotations;

namespace AlgoaVehicleTraders.Models.All
{
    public class BikeBrand
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public required string BrandName { get; set; }
    }
}
