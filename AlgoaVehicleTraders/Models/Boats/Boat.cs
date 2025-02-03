using System.ComponentModel.DataAnnotations;

namespace AlgoaVehicleTraders.Models.Boats
{
    public class Boat
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
        public required string Colour { get; set; }
        [Required]
        public required string Condition { get; set; }

        [Required]
        public required string Engine { get; set; }

        [Required]
        public int ConsoleLocation { get; set; }

        [Required]
        public int Status { get; set; }
        public DateTime? StatusChangeDate { get; set; }
    }
}
