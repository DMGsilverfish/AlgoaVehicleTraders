using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlgoaVehicleTraders.Models.All
{
    public class AddVehicleBoatViewModel
    {
        public int Id { get; set; }
        public string? Model {  get; set; }
        public int Brand { get; set; }

        public int Type { get; set; }
        public string? Colour { get; set; }
        public int Mileage { get; set; }
        public int Year { get; set; }
        public string? Condition { get; set; }
        public string? Engine {  get; set; }
        public int ConsoleLocation { get; set; }
        public double Price { get; set; }
        public int FuelType { get; set; }


        public int WaterDepth { get; set; }
        public int Status { get; set; }

        public DateTime? StatusChangeDate { get; set; }

        public bool RegisteredTrailer { get; set; }
        public bool FishFinder { get; set; }
        public bool LifeJackets { get; set; }
        public bool SafetyEquipment { get; set; }
        public bool VhfRadio { get; set; }
        public bool SkiTower { get; set; }
        public bool COF { get; set; }
        public bool BuoyancyCertificate { get; set; }
        public bool LiveWell { get; set; }

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
        public IEnumerable<SelectListItem>? Statuss { get; set; }
        public IEnumerable<SelectListItem>? WaterDepths { get; set; }

    }
}
