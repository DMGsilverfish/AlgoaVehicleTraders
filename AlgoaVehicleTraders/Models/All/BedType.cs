﻿using System.ComponentModel.DataAnnotations;

namespace AlgoaVehicleTraders.Models.All
{
    public class BedType
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public required string BedTypeName { get; set; }
    }
}
