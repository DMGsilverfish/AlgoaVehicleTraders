using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlgoaVehicleTraders.Models.All
{
    public class DropdownsEditViewModel
    {
        // All category
        public List<FuelType>? FuelTypes { get; set; }
        public int? SelectedFuelTypeId { get; set; }
        [StringLength(100, ErrorMessage = "Fuel type name cannot be longer than 100 characters.")]
        public string? FuelTypeName { get; set; }

        public List<Transmission>? Transmissions { get; set; }
        public int? SelectedTransmissionId { get; set; }
        [StringLength(100, ErrorMessage = "Transmission name cannot be longer than 100 characters.")]
        public string? TransmissionName { get; set; }

        // Car category
        public List<AlgoaVehicleTraders.Models.All.Type>? CarTypes { get; set; }
        public int? SelectedCarTypeId { get; set; }
        [StringLength(100, ErrorMessage = "Type name cannot be longer than 100 characters.")]
        public string? CarTypeName { get; set; }

        public List<Brand>? CarBrands { get; set; }
        public int? SelectedCarBrandId { get; set; }
        [StringLength(100, ErrorMessage = "Brand name cannot be longer than 100 characters.")]
        public string? CarBrandName { get; set; }

        public List<DriveTrain>? DriveTrains { get; set; }
        public int? SelectedDriveTrainId { get; set; }
        [StringLength(100, ErrorMessage = "Drive train name cannot be longer than 100 characters.")]
        public string? DriveTrainName { get; set; }

        // Bike category
        public List<BikeType>? BikeTypes { get; set; }
        public int? SelectedBikeTypeId { get; set; }
        [StringLength(100, ErrorMessage = "Bike type name cannot be longer than 100 characters.")]
        public string? BikeTypeName { get; set; }

        public List<BikeBrand>? BikeBrands { get; set; }
        public int? SelectedBikeBrandId { get; set; }
        [StringLength(100, ErrorMessage = "Brand name cannot be longer than 100 characters.")]
        public string? BikeBrandName { get; set; }

        // Boat category
        public List<BoatType>? BoatTypes { get; set; }
        public int? SelectedBoatTypeId { get; set; }
        [StringLength(100, ErrorMessage = "Boat type name cannot be longer than 100 characters.")]
        public string? BoatTypeName { get; set; }

        public List<BoatBrand>? BoatBrands { get; set; }
        public int? SelectedBoatBrandId { get; set; }
        [StringLength(100, ErrorMessage = "Brand name cannot be longer than 100 characters.")]
        public string? BoatBrandName { get; set; }

        public List<WaterDepth>? WaterDepths { get; set; }
        public int? SelectedWaterDepthId { get; set; }
        [StringLength(100, ErrorMessage = "Water depth name cannot be longer than 100 characters.")]
        public string? WaterDepthName { get; set; }

        // Caravan category
        public List<CaravanType>? CaravanTypes { get; set; }
        public int? SelectedCaravanTypeId { get; set; }
        [StringLength(100, ErrorMessage = "Caravan type name cannot be longer than 100 characters.")]
        public string? CaravanTypeName { get; set; }

        public List<CaravanBrand>? CaravanBrands { get; set; }
        public int? SelectedCaravanBrandId { get; set; }
        [StringLength(100, ErrorMessage = "Brand name cannot be longer than 100 characters.")]
        public string? CaravanBrandName { get; set; }

        //Trailer category
        public List<AxleType>? AxleTypes { get; set; }
        public int? SelectedAxleTypeId { get; set; }
        [StringLength(100, ErrorMessage = "Axle type name cannot be longer than 100 characters.")]
        public string? AxleTypeName { get; set; }

        public List<BrakedAxle>? BrakedAxleTypes { get; set; }
        public int? SelectedBrakedAxleTypeId { get; set; }
        [StringLength(100, ErrorMessage = "Braked axle type name cannot be longer than 100 characters.")]
        public string? BrakedAxleTypeName { get; set; }

        public List<TrailerBrand>? TrailerBrands { get; set; }
        public int? SelectedTrailerBrandId { get; set; }
        [StringLength(100, ErrorMessage = "Brand name cannot be longer than 100 characters.")]
        public string? TrailerBrandName { get; set; }
    }
}
