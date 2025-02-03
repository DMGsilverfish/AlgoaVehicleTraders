using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlgoaVehicleTraders.Data.Migrations
{
    /// <inheritdoc />
    public partial class bikeAdjustment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(name: "Bike", columns: table => new { ID = table.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"), Model = table.Column<string>(nullable: false), Brand = table.Column<int>(nullable: false), Type = table.Column<int>(nullable: false), Price = table.Column<double>(nullable: false), Mileage = table.Column<int>(nullable: false), Year = table.Column<int>(nullable: false), FuelType = table.Column<int>(nullable: false), Transmission = table.Column<int>(nullable: false), Status = table.Column<int>(nullable: false), StatusChangeDate = table.Column<DateTime>(nullable: true), Colour = table.Column<string>(nullable: false), Condition = table.Column<string>(nullable: false), EngineSize = table.Column<string>(nullable: false) }, constraints: table => { table.PrimaryKey("PK_Bike", x => x.ID); });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Bike");
        }
    }
}
