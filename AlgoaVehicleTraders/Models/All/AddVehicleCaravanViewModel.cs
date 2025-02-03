using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlgoaVehicleTraders.Models.All
{
    public class AddVehicleCaravanViewModel
    {
        public int CaravanId { get; set; }
        public int Brand {  get; set; }
        public string? Model {  get; set; }
        public int Type { get; set; }
        public int Berth { get; set; }
        
        public string? KitchenHas {  set; get; }
        public string? BathroomHas { set; get; }
        public string? Colour { get; set; }
        public double Price { get; set; }
        public int Year { get; set; }
        public string? Condition { get; set; }
        public string? BedType { get; set; }
        public int Status { get; set; }
        public DateTime? StatusChangeDate { get; set; }


        public bool Awning { get; set; }
        public bool WaterTank { get; set; }
        public bool Geyser { get; set; }
        public bool Movers { get; set; }
        public bool CaravanCover { get; set; }
        public bool Add_A_Room { get; set; }
        public bool MultiRoom { get; set; }
        public bool SpareKey { get; set; }
        public bool SpareTyre { get; set; }
        public bool FullTent { get; set; }

        public IFormFile[]? ExteriorImages { get; set; }
        public string[]? ExteriorImageBase64 { get; set; }
        public IFormFile[]? InteriorImages { get; set; }
        public string[]? InteriorImageBase64 { get; set; }
        public IFormFile[]? OtherImages { get; set; }
        public string[]? OtherImageBase64 { get; set; }

        public IEnumerable<SelectListItem>? Brands { get; set; }
        public IEnumerable<SelectListItem>? Types { get; set; }
        
        public IEnumerable<SelectListItem>? Statuss { get; set; }
    }
}
