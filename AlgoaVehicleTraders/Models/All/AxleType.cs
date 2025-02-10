using System.ComponentModel.DataAnnotations;

namespace AlgoaVehicleTraders.Models.All
{
    public class AxleType
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public required string AxleName { get; set; }

    }
}
