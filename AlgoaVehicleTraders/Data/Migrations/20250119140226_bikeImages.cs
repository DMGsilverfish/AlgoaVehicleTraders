using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlgoaVehicleTraders.Data.Migrations
{
    /// <inheritdoc />
    public partial class bikeImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Exterior1",
                table: "BikeAdditional",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Exterior2",
                table: "BikeAdditional",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Exterior3",
                table: "BikeAdditional",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Exterior4",
                table: "BikeAdditional",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Exterior5",
                table: "BikeAdditional",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Exterior6",
                table: "BikeAdditional",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Interior1",
                table: "BikeAdditional",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Interior2",
                table: "BikeAdditional",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Interior3",
                table: "BikeAdditional",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Interior4",
                table: "BikeAdditional",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Other1",
                table: "BikeAdditional",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Other2",
                table: "BikeAdditional",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Exterior1",
                table: "BikeAdditional");

            migrationBuilder.DropColumn(
                name: "Exterior2",
                table: "BikeAdditional");

            migrationBuilder.DropColumn(
                name: "Exterior3",
                table: "BikeAdditional");

            migrationBuilder.DropColumn(
                name: "Exterior4",
                table: "BikeAdditional");

            migrationBuilder.DropColumn(
                name: "Exterior5",
                table: "BikeAdditional");

            migrationBuilder.DropColumn(
                name: "Exterior6",
                table: "BikeAdditional");

            migrationBuilder.DropColumn(
                name: "Interior1",
                table: "BikeAdditional");

            migrationBuilder.DropColumn(
                name: "Interior2",
                table: "BikeAdditional");

            migrationBuilder.DropColumn(
                name: "Interior3",
                table: "BikeAdditional");

            migrationBuilder.DropColumn(
                name: "Interior4",
                table: "BikeAdditional");

            migrationBuilder.DropColumn(
                name: "Other1",
                table: "BikeAdditional");

            migrationBuilder.DropColumn(
                name: "Other2",
                table: "BikeAdditional");
        }
    }
}
