using System.ComponentModel.DataAnnotations;

namespace AlgoaVehicleTraders.Models.Caravans
{
    public class Caravan
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int Brand {  get; set; }

        [Required]
        public required string Model { get; set; }

        [Required]
        public int Type { get; set; }

        [Required]
        public int Berth { get; set; }

        public string? KitchenHas { get; set; }

        public string? BathroomHas { get; set; }

        [Required]
        public required string Colour {  get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public required string Condition { get; set; }

        [Required]
        public required string BedType { get; set; }

        [Required]
        public int Status { get; set; }
        public DateTime? StatusChangeDate { get; set; }

    }
}
