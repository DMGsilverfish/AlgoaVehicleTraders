using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlgoaVehicleTraders.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldsCarAdditional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Alarm",
                table: "CarAdditional",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CentralLocking",
                table: "CarAdditional",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ElectricMirrors",
                table: "CarAdditional",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HeatedSeats",
                table: "CarAdditional",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LeatherSeats",
                table: "CarAdditional",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MultiFunctionSteerWheel",
                table: "CarAdditional",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NumberDoors",
                table: "CarAdditional",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberSeats",
                table: "CarAdditional",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ParkDistanceControl",
                table: "CarAdditional",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PowerSteering",
                table: "CarAdditional",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Radio",
                table: "CarAdditional",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SpareKey",
                table: "CarAdditional",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SpeedControl",
                table: "CarAdditional",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TowBar",
                table: "CarAdditional",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alarm",
                table: "CarAdditional");

            migrationBuilder.DropColumn(
                name: "CentralLocking",
                table: "CarAdditional");

            migrationBuilder.DropColumn(
                name: "ElectricMirrors",
                table: "CarAdditional");

            migrationBuilder.DropColumn(
                name: "HeatedSeats",
                table: "CarAdditional");

            migrationBuilder.DropColumn(
                name: "LeatherSeats",
                table: "CarAdditional");

            migrationBuilder.DropColumn(
                name: "MultiFunctionSteerWheel",
                table: "CarAdditional");

            migrationBuilder.DropColumn(
                name: "NumberDoors",
                table: "CarAdditional");

            migrationBuilder.DropColumn(
                name: "NumberSeats",
                table: "CarAdditional");

            migrationBuilder.DropColumn(
                name: "ParkDistanceControl",
                table: "CarAdditional");

            migrationBuilder.DropColumn(
                name: "PowerSteering",
                table: "CarAdditional");

            migrationBuilder.DropColumn(
                name: "Radio",
                table: "CarAdditional");

            migrationBuilder.DropColumn(
                name: "SpareKey",
                table: "CarAdditional");

            migrationBuilder.DropColumn(
                name: "SpeedControl",
                table: "CarAdditional");

            migrationBuilder.DropColumn(
                name: "TowBar",
                table: "CarAdditional");
        }
    }
}
