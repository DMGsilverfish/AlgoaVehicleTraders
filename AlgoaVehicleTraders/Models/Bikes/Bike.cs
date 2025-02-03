using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlgoaVehicleTraders.Models.Bikes
{
    public class Bike
    {

        [Key]
        public int ID { get; set; }

        [Required]
        public required string Model { get; set; }
        [Required]
        public int Brand { get; set; }
        [Required]
        public int Type { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Mileage { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int FuelType { get; set; }
        [Required]
        public int Transmission { get; set; }

        [Required]
        public int Status { get; set; }
        public DateTime? StatusChangeDate { get; set; }
        [Required]
        public required string Colour { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(MAX)")]
        public required string Condition { get; set; }

        [Required]
        public required string EngineSize { get; set; }
    }
}
