using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlgoaVehicleTraders.Models.All
{
    public class DropdownsDeleteViewModel
    {
        public List<FuelType>? FuelTypes { get; set; }
        public int? SelectedFuelTypeId { get; set; }

        public List<Transmission>? Transmissions { get; set; }
        public int? SelectedTransmissionId { get; set; }

        public List<AlgoaVehicleTraders.Models.All.Type>? CarTypes { get; set; }
        public int? SelectedCarTypeId { get; set; }

        public List<Brand>? CarBrands { get; set; }
        public int? SelectedCarBrandId { get; set; }

        public List<DriveTrain>? DriveTrains { get; set; }
        public int? SelectedDriveTrainId { get; set; }

        public List<BikeType>? BikeTypes { get; set; }
        public int? SelectedBikeTypeId { get; set; }

        public List<BikeBrand>? BikeBrands { get; set; }
        public int? SelectedBikeBrandId { get; set; }

        public List<BoatType>? BoatTypes { get; set; }
        public int? SelectedBoatTypeId { get; set; }

        public List<BoatBrand>? BoatBrands { get; set; }
        public int? SelectedBoatBrandId { get; set; }

        public List<WaterDepth>? WaterDepths { get; set; }
        public int? SelectedWaterDepthId { get; set; }

        public List<CaravanType>? CaravanTypes { get; set; }
        public int? SelectedCaravanTypeId { get; set; }

        public List<CaravanBrand>? CaravanBrands { get; set; }
        public int? SelectedCaravanBrandId { get; set; }

        public List<AxleType>? AxleTypes { get; set; }
        public int? SelectedAxleTypeId { get; set; }

        public List<BrakedAxle>? BrakedAxleTypes { get; set; }
        public int? SelectedBrakedAxleTypeId { get; set; }

        public List<TrailerBrand>? TrailerBrands { get; set; }
        public int? SelectedTrailerBrandId { get; set; }
    }
        
}
