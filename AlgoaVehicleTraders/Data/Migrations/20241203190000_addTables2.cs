using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlgoaVehicleTraders.Data.Migrations
{
    /// <inheritdoc />
    public partial class addTables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FuelType = table.Column<int>(type: "int", nullable: false),
                    Transmission = table.Column<int>(type: "int", nullable: false),
                    DriveTrain = table.Column<int>(type: "int", nullable: false),
                    Colour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CarAdditional",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarID = table.Column<int>(type: "int", nullable: false),
                    AC = table.Column<bool>(type: "bit", nullable: false),
                    ElectricWindows = table.Column<int>(type: "int", nullable: false),
                    SpareTyre = table.Column<bool>(type: "bit", nullable: false),
                    ReverseCamera = table.Column<bool>(type: "bit", nullable: false),
                    Exterior1 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Exterior2 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Exterior3 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Exterior4 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Exterior5 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Exterior6 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Interior1 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Interior2 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Interior3 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Interior4 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Other1 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Other2 = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarAdditional", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "CarAdditional");
        }
    }
}
