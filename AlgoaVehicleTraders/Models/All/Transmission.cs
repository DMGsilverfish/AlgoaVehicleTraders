using System.ComponentModel.DataAnnotations;


namespace AlgoaVehicleTraders.Models.All
{
    public class Transmission
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string TransmissionName { get; set; }
    }
}
