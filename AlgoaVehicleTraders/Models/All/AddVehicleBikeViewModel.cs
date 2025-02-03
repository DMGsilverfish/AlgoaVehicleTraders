using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlgoaVehicleTraders.Models.All
{
    public class AddVehicleBikeViewModel
    {
        public int Id { get; set; }
        public int Brand {  get; set; }
        public string? Model {  get; set; }
        public int Type { get; set; }
        public string? Colour { get; set; }
        public int Mileage { get; set; }
        public int Year { get; set; }
        public string? EngineSize { get; set; }
        public int FuelType { get; set; }
        public int Transmission { get; set; }
        public double Price { get; set; }
        public string? Condition { get; set; }
        public int Status { get; set; }
        public DateTime? StatusChangeDate { get; set; }

        public bool CenterStand { get; set; }
        public bool TopBox { get; set; }
        public bool Panniers { get; set; }
        public bool RaisedScreen { get; set; }
        public bool HeatedGrips { get; set; }
        public bool OffRoadCapable { get; set; }

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
    }
}
