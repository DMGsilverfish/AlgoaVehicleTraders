using System.ComponentModel.DataAnnotations;

namespace AlgoaVehicleTraders.Models.All
{
    public class BoatEngine
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public required string Name { get; set; }
    }
}
