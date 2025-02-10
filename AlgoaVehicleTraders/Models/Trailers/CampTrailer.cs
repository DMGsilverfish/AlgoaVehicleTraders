using System.ComponentModel.DataAnnotations;

namespace AlgoaVehicleTraders.Models.Trailers
{
    public class CampTrailer
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int TrailerID { get; set; }

        [Required]
        public required string KitchenHas {  get; set; }
        [Required]
        public required string Sleeper { get; set; }
        public bool SpareTyre { get; set; }
        public bool Awning {  get; set; }
        public bool Tent {  get; set; }
        public bool Geyser { get; set; }
        public bool WaterTank { get; set; }
        public bool WaterPump { get; set; }
        public bool VoltPowerSupply_12 { get; set; }
        public bool VoltPowerSupplt_220 { get; set; }
        public bool Battery { get; set; }
        public bool ChargeSystem { get; set; }
        public bool Add_A_Room { get; set; }
        public bool GasBottles { get; set; }

    }
}
