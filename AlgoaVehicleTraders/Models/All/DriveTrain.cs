using System.ComponentModel.DataAnnotations;


namespace AlgoaVehicleTraders.Models.All
{
    public class DriveTrain
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string DriveTrainName { get; set; }
    }
}
