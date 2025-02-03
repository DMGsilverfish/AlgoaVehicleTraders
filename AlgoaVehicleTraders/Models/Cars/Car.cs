using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlgoaVehicleTraders.Models.Cars
{
    public class Car
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Model { get; set; }
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
        public int DriveTrain { get; set; }
        [Required]
        public string Colour { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(MAX)")]
        public string Condition { get; set; }

        [Required]
        public string EngineSize { get; set; }

        [Required]
        public int Status { get; set; }

        public DateTime? StatusChangeDate { get; set; }
    }
}
