using System.ComponentModel.DataAnnotations;


namespace AlgoaVehicleTraders.Models.Cars
{
    public class CarAdditional
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int CarID { get; set; }

        public bool AC { get; set; }

        public int ElectricWindows { get; set; } //number
        public bool Sunroof { get; set; }
        public bool ReverseCamera { get; set; }

        public bool LeatherSeats { get; set; }
        public bool TowBar {  get; set; }
        public bool PowerSteering { get; set; }
        public bool CentralLocking { get; set; }
        public bool MultiFunctionSteerWheel { get; set; }
        public bool Alarm {  get; set; }
        public bool Radio { get; set; }
        public bool SpeedControl { get; set; }
        public bool ParkDistanceControl { get; set; }
        public bool HeatedSeats { get; set; }
        public bool SpareKey {  get; set; }
        public bool ElectricMirrors { get; set; }
        public bool FullServiceHistory { get; set; }

        public int NumberSeats { get; set; } //number
        public int NumberDoors { get; set; } //number
        
      
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
