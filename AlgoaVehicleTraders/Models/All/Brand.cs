using System.ComponentModel.DataAnnotations;

namespace AlgoaVehicleTraders.Models.All
{
    public class Brand
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string BrandName { get; set; }
    }
}
