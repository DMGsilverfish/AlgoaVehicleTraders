using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlgoaVehicleTraders.Models.All
{
    public class AddVehicleViewModel
    {
        public int Id { get; set; } // Add this property if it's missing
        public int Brand { get; set; }
        public string? Model { get; set; }
        public int Type { get; set; }
        public string? Colour { get; set; }
        public int Mileage { get; set; }
        public int Year { get; set; }
        public string? EngineSize { get; set; }
        public int FuelType { get; set; }
        public int Transmission { get; set; }
        public double Price { get; set; }
        public string? Condition { get; set; }
        public int DriveTrain { get; set; }

        public int Status { get; set; }
        public DateTime? StatusChangeDate { get; set; }

        //additional
        public bool AC { get; set; }

        public bool Sunroof { get; set; }
        public bool LeatherSeats { get; set; }
        public bool TowBar { get; set; }
        public bool PowerSteering { get; set; }
        public bool CentralLocking { get; set; }
        public bool MultiFunctionSteerWheel { get; set; }

        public bool Alarm { get; set; }
        public bool Radio { get; set; }
        public bool ReverseCamera { get; set; }
        public bool FullServiceHistory { get; set; }

        public bool SpeedControl { get; set; }
        public bool ParkDistanceControl { get; set; }
        public bool HeatedSeats { get; set; }
        public bool SpareKey { get; set; }
        public bool ElectricMirrors { get; set; }
        public int NumberSeats { get; set; }
        public int NumberDoors { get; set; }

        public int ElectricWindows { get; set; }


        public IFormFile[]? ExteriorImages { get; set; }
        public string[]? ExteriorImageBase64 { get; set; }
        public IFormFile[]? InteriorImages { get; set; }
        public string[]? InteriorImageBase64 { get; set; }
        public IFormFile[]? OtherImages { get; set; }
        public string[]? OtherImageBase64 { get; set; }

        public IEnumerable<SelectListItem>? Brands { get; set; }
        public IEnumerable<SelectListItem>? Types { get; set; }
        public IEnumerable<SelectListItem>? FuelTypes { get; set; }
        public IEnumerable<SelectListItem>? Transmissions { get; set; }
        public IEnumerable<SelectListItem>? DriveTrains { get; set; }
        public IEnumerable<SelectListItem>? Statuss { get; set; }

    }


}
