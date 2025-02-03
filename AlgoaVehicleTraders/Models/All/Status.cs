using System.ComponentModel.DataAnnotations;

namespace AlgoaVehicleTraders.Models.All
{
    public class Status
    {
        [Key]
        public int ID {  get; set; }

        [Required]
        public string StatusName { get; set; }

        public string? StatusDescription { get; set; }
    }
}
