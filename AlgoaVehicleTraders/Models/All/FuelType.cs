using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;


namespace AlgoaVehicleTraders.Models.All
{
    public class FuelType
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string FuelTypeName { get; set; }    
    }
}
