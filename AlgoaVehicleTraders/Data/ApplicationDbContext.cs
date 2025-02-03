using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using AlgoaVehicleTraders.Models.Cars;
using AlgoaVehicleTraders.Models.All;
using AlgoaVehicleTraders.Models.Bikes;
using AlgoaVehicleTraders.Models.Boats;
using AlgoaVehicleTraders.Models.Caravans;

namespace AlgoaVehicleTraders.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Car { get; set; }
        public DbSet<CarAdditional> CarAdditional { get; set; }


        public DbSet<Bike> Bike { get; set; }
        public DbSet<BikeAdditional> BikeAdditional {get; set; }
        public DbSet<Boat> Boat { get; set; }
        public DbSet<BoatAdditional> BoatAdditional { get; set; }

        public DbSet<Caravan> Caravan { get; set; }
        public DbSet<CaravanAdditional> CaravanAdditional { get; set; }



        public DbSet<Brand> Brand { get; set; }
        public DbSet<BikeBrand> BikeBrand { get; set; }
        public DbSet<BoatBrand> BoatBrand { get; set; }
        public DbSet<CaravanBrand> CaravanBrand { get; set; }

        public DbSet<DriveTrain> DriveTrain { get; set; }
        public DbSet<FuelType> FuelType { get; set; }
        public DbSet<Transmission> Transmission { get; set; }
        public DbSet<AlgoaVehicleTraders.Models.All.Type> Type { get; set; }
        public DbSet<BikeType> BikeType { get; set; }
        public DbSet<CaravanType> CaravanType { get; set; }


        public DbSet<Status> Status { get; set; }
        public DbSet<BoatEngine> BoatEngine { get; set; }
        public DbSet<BoatType> BoatType { get; set; }
        public DbSet<WaterDepth> WaterDepth { get; set; }
        public DbSet<BedType> BedType { get; set; }



        public DbSet<CompanyDetails> CompanyDetails { get; set; }
    }
}
