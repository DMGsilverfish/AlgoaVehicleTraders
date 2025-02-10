using System.ComponentModel.DataAnnotations;

namespace AlgoaVehicleTraders.Models.Trailers
{
    public class Trailer
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public required string Model { get; set; }
        [Required]
        public int Brand {  get; set; }
        [Required]
        public int Type { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int AxleType { get; set; }
        [Required]
        public int BrakedAxle {  get; set; }
        [Required]
        public int NumberAxle { get; set; }
        [Required]
        public int Year { get; set; }

        [Required]
        public required string TyreSize { get; set; }
        [Required]
        public required string Length { get; set; }

        // Exterior images
        public byte[]? Exterior1 { get; set; }
        public byte[]? Exterior2 { get; set; }
        public byte[]? Exterior3 { get; set; }
        public byte[]? Exterior4 { get; set; }
        public byte[]? Exterior5 { get; set; }
        public byte[]? Exterior6 { get; set; }

        // Interior images
        public byte[]? Interior1 { get; set; }
        public byte[]? Interior2 { get; set; }
        public byte[]? Interior3 { get; set; }
        public byte[]? Interior4 { get; set; }
        public byte[]? Interior5 { get; set; }
        public byte[]? Interior6 { get; set; }

        // Other images
        public byte[]? Other1 { get; set; }
        public byte[]? Other2 { get; set; }

        public string? Comments { get; set; }

        [Required]
        public int Status { get; set; }

        public DateTime? StatusChangeDate { get; set; }

    }
}
