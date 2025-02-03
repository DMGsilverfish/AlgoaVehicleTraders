using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlgoaVehicleTraders.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCaravanTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Awning",
                table: "Caravan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BathroomHas",
                table: "Caravan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BedType",
                table: "Caravan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Berth",
                table: "Caravan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Brand",
                table: "Caravan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Colour",
                table: "Caravan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Condition",
                table: "Caravan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KitchenHas",
                table: "Caravan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Caravan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Caravan",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Caravan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StatusChangeDate",
                table: "Caravan",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Caravan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CaravanAdditional",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaravanID = table.Column<int>(type: "int", nullable: false),
                    WaterTank = table.Column<bool>(type: "bit", nullable: false),
                    Geyser = table.Column<bool>(type: "bit", nullable: false),
                    Movers = table.Column<bool>(type: "bit", nullable: false),
                    CaravanCover = table.Column<bool>(type: "bit", nullable: false),
                    Add_A_Room = table.Column<bool>(type: "bit", nullable: false),
                    MultiRoon = table.Column<bool>(type: "bit", nullable: false),
                    SpareKey = table.Column<bool>(type: "bit", nullable: false),
                    SpareTyre = table.Column<bool>(type: "bit", nullable: false),
                    FullServiceHistory = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaravanAdditional", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaravanAdditional");

            migrationBuilder.DropColumn(
                name: "Awning",
                table: "Caravan");

            migrationBuilder.DropColumn(
                name: "BathroomHas",
                table: "Caravan");

            migrationBuilder.DropColumn(
                name: "BedType",
                table: "Caravan");

            migrationBuilder.DropColumn(
                name: "Berth",
                table: "Caravan");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Caravan");

            migrationBuilder.DropColumn(
                name: "Colour",
                table: "Caravan");

            migrationBuilder.DropColumn(
                name: "Condition",
                table: "Caravan");

            migrationBuilder.DropColumn(
                name: "KitchenHas",
                table: "Caravan");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Caravan");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Caravan");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Caravan");

            migrationBuilder.DropColumn(
                name: "StatusChangeDate",
                table: "Caravan");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Caravan");
        }
    }
}
