using AlgoaVehicleTraders.Models.Cars;

namespace AlgoaVehicleTraders.Models.Bikes
{
    public class BikeViewModel
    {
        public Bike Bike { get; set; }
        public BikeAdditional Additional { get; set; }
        public string Brand { get; set; }
        public string FuelType { get; set; }
        public string Transmission { get; set; }
    }
}
