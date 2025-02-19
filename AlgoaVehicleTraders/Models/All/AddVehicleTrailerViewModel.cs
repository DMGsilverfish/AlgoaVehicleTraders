using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlgoaVehicleTraders.Models.All
{
    public class AddVehicleTrailerViewModel
    {
        public int Id { get; set; }
        public string? Model { get; set; }
        public int Brand { get; set; }
        public int Type { get; set; }
        public double Price { get; set; }
        public int AxleType { get; set; }
        public int BrakedAxle { get; set; }
        public int NumberAxle { get; set; }
        public string? TyreSize { get; set; }
        public string? Length { get; set; }
        public int Year { get; set; }
        public bool TailGate { get; set; }
        public string? Comments { get; set; }
        public int Status { get; set; }
        public DateTime? StatusChangeDate { get; set; }

        // Images
        public IFormFile[]? ExteriorImages { get; set; }
        public string[]? ExteriorImageBase64 { get; set; }
        public IFormFile[]? InteriorImages { get; set; }
        public string[]? InteriorImageBase64 { get; set; }
        public IFormFile[]? OtherImages { get; set; }
        public string[]? OtherImageBase64 { get; set; }

        // Dropdown Lists

        public IEnumerable<SelectListItem>? Brands { get; set; }
        public IEnumerable<SelectListItem>? Types { get; set; }
        public IEnumerable<SelectListItem>? AxleTypes { get; set; }
        public IEnumerable<SelectListItem>? BrakedAxles { get; set; }
        public IEnumerable<SelectListItem>? DriveTrains { get; set; }
        public IEnumerable<SelectListItem>? Statuss { get; set; }


        public bool ShowCampTrailerFields => Type == 0; // Show if type is "Camp"
        public CampTrailerViewModel? CampTrailer { get; set; }
    }

    public class CampTrailerViewModel
    {
        public int TrailerID { get; set; }
        public string KitchenHas { get; set; } = string.Empty;
        public string Sleeper { get; set; } = string.Empty;
        public bool SpareTyre { get; set; }
        public bool Awning { get; set; }
        public bool Tent { get; set; }
        public bool Geyser { get; set; }
        public bool WaterTank { get; set; }
        public bool WaterPump { get; set; }
        public bool VoltPowerSupply_12 { get; set; }
        public bool VoltPowerSupply_220 { get; set; }
        public bool Battery { get; set; }
        public bool ChargeSystem { get; set; }
        public bool Add_A_Room { get; set; }
        public bool GasBottles { get; set; }
    }
}
