using System.ComponentModel.DataAnnotations;

namespace AlgoaVehicleTraders.Models.All
{
    public class TrailerType
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public required string TypeName { get; set; }

    }
}
