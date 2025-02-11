using System.ComponentModel.DataAnnotations;

namespace AlgoaVehicleTraders.Models.All
{
    public class DropdownsViewModel
    {
        // All
        [StringLength(100, ErrorMessage = "Fuel Type name cannot be longer than 100 characters.")]
        public string? FuelTypeName { get; set; }

        [StringLength(100, ErrorMessage = "Transmission name cannot be longer than 100 characters.")]
        public string? TransmissionName { get; set; }

        // Car
        [StringLength(100, ErrorMessage = "Type name cannot be longer than 100 characters.")]
        public string? CarTypeName { get; set; }

        [StringLength(100, ErrorMessage = "Brand name cannot be longer than 100 characters.")]
        public string? CarBrandName { get; set; }

        [StringLength(100, ErrorMessage = "Drive Train name cannot be longer than 100 characters.")]
        public string? DriveTrainName { get; set; }

        // Bike
        [StringLength(100, ErrorMessage = "Type name cannot be longer than 100 characters.")]
        public string? BikeTypeName { get; set; }

        [StringLength(100, ErrorMessage = "Brand name cannot be longer than 100 characters.")]
        public string? BikeBrandName { get; set; }

        // Boat
        [StringLength(100, ErrorMessage = "Type name cannot be longer than 100 characters.")]
        public string? BoatTypeName { get; set; }

        [StringLength(100, ErrorMessage = "Brand name cannot be longer than 100 characters.")]
        public string? BoatBrandName { get; set; }

        [StringLength(100, ErrorMessage = "Water Depth name cannot be longer than 100 characters.")]
        public string? WaterDepthName { get; set; }

        // Caravan
        [StringLength(100, ErrorMessage = "Type name cannot be longer than 100 characters.")]
        public string? CaravanTypeName { get; set; }

        [StringLength(100, ErrorMessage = "Brand name cannot be longer than 100 characters.")]
        public string? CaravanBrandName { get; set; }

        //Trailer
        [StringLength(100, ErrorMessage = "Brand name cannot be longer than 100 characters.")]
        public string? TrailerBrandName { get; set; }

        [StringLength(100, ErrorMessage = "Type name cannot be longer than 100 characters.")]
        public string? AxleTypeName { get; set; }

        [StringLength(100, ErrorMessage = "Type name cannot be longer than 100 characters.")]
        public string? BrakedAxleTypeName { get; set; }
    }
}
