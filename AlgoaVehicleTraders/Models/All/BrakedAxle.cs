using System.ComponentModel.DataAnnotations;

namespace AlgoaVehicleTraders.Models.All
{
    public class BrakedAxle
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public required string BrakedAxleName { get; set; }
    }
}
