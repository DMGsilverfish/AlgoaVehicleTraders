using System.ComponentModel.DataAnnotations;

namespace AlgoaVehicleTraders.Models.Bikes
{
    public class BikeAdditional
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int BikeID { get; set; }
        [Required]
        public bool CenterStand { get; set; }
        [Required]
        public bool TopBox { get; set; }
        [Required]
        public bool Panniers { get; set; }
        [Required]
        public bool RaisedScreen {  get; set; }
        [Required]
        public bool HeatedGrips { get; set; }
        [Required]
        public bool OffRoadCapable { get; set; }


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
