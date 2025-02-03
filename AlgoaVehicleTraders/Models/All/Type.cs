using System.ComponentModel.DataAnnotations;


namespace AlgoaVehicleTraders.Models.All
{
    public class Type
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string TypeName { get; set; }
    }
}
