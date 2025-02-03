using System.ComponentModel.DataAnnotations;

namespace AlgoaVehicleTraders.Models.All
{
    public class BoatType
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public required string BoatTypeName { get; set; }

    }
}
