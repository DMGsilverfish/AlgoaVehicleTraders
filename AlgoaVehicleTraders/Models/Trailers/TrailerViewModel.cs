namespace AlgoaVehicleTraders.Models.Trailers
{
    public class TrailerViewModel
    {
        public Trailer Trailer { get; set; }
        public CampTrailer CampTrailer { get; set; }
        public required string Brand { get; set; }
        public required string Type { get; set; }
        public required string AxleType { get; set; }
        public required string BrakedAxle {  get; set; }


    }
}
