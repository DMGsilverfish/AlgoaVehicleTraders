using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlgoaVehicleTraders.Data.Migrations
{
    /// <inheritdoc />
    public partial class dc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "Car",
            columns: table => new
            {
                ID = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Model = table.Column<string>(nullable: false),
                Brand = table.Column<int>(nullable: false),
                Type = table.Column<int>(nullable: false),
                Price = table.Column<double>(nullable: false),
                Mileage = table.Column<int>(nullable: false),
                Year = table.Column<int>(nullable: false),
                FuelType = table.Column<int>(nullable: false),
                Transmission = table.Column<int>(nullable: false),
                DriveTrain = table.Column<int>(nullable: false),
                Colour = table.Column<string>(nullable: false),
                Condition = table.Column<string>(nullable: false),
                EngineSize = table.Column<string>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Car", x => x.ID);
            });
            migrationBuilder.CreateTable(
           name: "CarAdditional",
           columns: table => new
           {
               ID = table.Column<int>(nullable: false)
                   .Annotation("SqlServer:Identity", "1, 1"),
               CarID = table.Column<int>(nullable: false),
               AC = table.Column<bool>(nullable: false),
               ElectricWindows = table.Column<int>(nullable: false),
               SpareTyre = table.Column<bool>(nullable: false),
               ReverseCamera = table.Column<bool>(nullable: false),
               LeatherSeats = table.Column<bool>(nullable: false),
               TowBar = table.Column<bool>(nullable: false),
               PowerSteering = table.Column<bool>(nullable: false),
               CentralLocking = table.Column<bool>(nullable: false),
               MultiFunctionSteerWheel = table.Column<bool>(nullable: false),
               Alarm = table.Column<bool>(nullable: false),
               Radio = table.Column<bool>(nullable: false),
               SpeedControl = table.Column<bool>(nullable: false),
               ParkDistanceControl = table.Column<bool>(nullable: false),
               HeatedSeats = table.Column<bool>(nullable: false),
               SpareKey = table.Column<bool>(nullable: false),
               ElectricMirrors = table.Column<bool>(nullable: false),
               NumberSeats = table.Column<int>(nullable: false),
               NumberDoors = table.Column<int>(nullable: false),
               Exterior1 = table.Column<byte[]>(nullable: true),
               Exterior2 = table.Column<byte[]>(nullable: true),
               Exterior3 = table.Column<byte[]>(nullable: true),
               Exterior4 = table.Column<byte[]>(nullable: true),
               Exterior5 = table.Column<byte[]>(nullable: true),
               Exterior6 = table.Column<byte[]>(nullable: true),
               Interior1 = table.Column<byte[]>(nullable: true),
               Interior2 = table.Column<byte[]>(nullable: true),
               Interior3 = table.Column<byte[]>(nullable: true),
               Interior4 = table.Column<byte[]>(nullable: true),
               Other1 = table.Column<byte[]>(nullable: true),
               Other2 = table.Column<byte[]>(nullable: true)
           },
           constraints: table =>
           {
               table.PrimaryKey("PK_CarAdditional", x => x.ID);
               table.ForeignKey(
                   name: "FK_CarAdditional_Car_CarID",
                   column: x => x.CarID,
                   principalTable: "Car",
                   principalColumn: "ID",
                   onDelete: ReferentialAction.Cascade);
           });

            migrationBuilder.CreateIndex(
                name: "IX_CarAdditional_CarID",
                table: "CarAdditional",
                column: "CarID");
        }

    

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        migrationBuilder.DropTable(
        name: "CarAdditional");

        migrationBuilder.DropTable(
            name: "Car");
    }
    }
}
