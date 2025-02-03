using System.ComponentModel.DataAnnotations;

namespace AlgoaVehicleTraders.Models.Caravans
{
    public class CaravanAdditional
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int CaravanID { get; set; }
        [Required]
        public bool Awning { get; set; }

        [Required]
        public bool WaterTank { get; set; }
        [Required]
        public bool Geyser { get; set; }
        [Required]
        public bool Movers { get; set; }
        [Required]
        public bool CaravanCover { get; set; }
        [Required]
        public bool Add_A_Room { get; set; }

        [Required]
        public bool MultiRoom { get; set; }

        [Required]
        public bool SpareKey { get; set; }
        [Required]
        public bool SpareTyre { get; set; }

        [Required]
        public bool FullTent { get; set; }

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

        // Other images
        public byte[]? Other1 { get; set; }
        public byte[]? Other2 { get; set; }

    }
}
