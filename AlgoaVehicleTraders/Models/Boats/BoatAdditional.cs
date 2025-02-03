using System.ComponentModel.DataAnnotations;

namespace AlgoaVehicleTraders.Models.Boats
{
    public class BoatAdditional
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int BoatID { get; set; }
        [Required]
        public int WaterDepth { get; set; }

        [Required]
        public bool RegisteredTrailer { get; set; }
        [Required]
        public bool FishFinder { get; set; }
        [Required]
        public bool LifeJackets { get; set; }

        [Required]
        public bool SafetyEquipment { get; set; }
        [Required]
        public bool VhfRadio { get; set; }
        [Required]
        public bool SkiTower { get; set; }
        [Required]
        public bool COF {  get; set; }
        [Required]
        public bool BuoyancyCertificate { get; set; }

        [Required]
        public bool LiveWell {  get; set; }

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
