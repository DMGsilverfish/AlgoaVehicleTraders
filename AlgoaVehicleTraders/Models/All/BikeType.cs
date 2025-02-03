using System.ComponentModel.DataAnnotations;

namespace AlgoaVehicleTraders.Models.All
{
    public class BikeType
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public required string BikeTypeName { get; set; }

    }
}
