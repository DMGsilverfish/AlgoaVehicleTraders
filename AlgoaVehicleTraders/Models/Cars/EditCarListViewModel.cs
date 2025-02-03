namespace AlgoaVehicleTraders.Models.Cars
{
    public class EditCarListViewModel
    {
        public int ID { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public int Mileage { get; set; }
        public string ExteriorImage1Base64 { get; set; }
    }
}
