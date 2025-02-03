using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlgoaVehicleTraders.Data.Migrations
{
    /// <inheritdoc />
    public partial class addBoatImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Exterior1",
                table: "BoatAdditional",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Exterior2",
                table: "BoatAdditional",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Exterior3",
                table: "BoatAdditional",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Exterior4",
                table: "BoatAdditional",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Exterior5",
                table: "BoatAdditional",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Exterior6",
                table: "BoatAdditional",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Interior1",
                table: "BoatAdditional",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Interior2",
                table: "BoatAdditional",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Interior3",
                table: "BoatAdditional",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Interior4",
                table: "BoatAdditional",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Other1",
                table: "BoatAdditional",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Other2",
                table: "BoatAdditional",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Exterior1",
                table: "BoatAdditional");

            migrationBuilder.DropColumn(
                name: "Exterior2",
                table: "BoatAdditional");

            migrationBuilder.DropColumn(
                name: "Exterior3",
                table: "BoatAdditional");

            migrationBuilder.DropColumn(
                name: "Exterior4",
                table: "BoatAdditional");

            migrationBuilder.DropColumn(
                name: "Exterior5",
                table: "BoatAdditional");

            migrationBuilder.DropColumn(
                name: "Exterior6",
                table: "BoatAdditional");

            migrationBuilder.DropColumn(
                name: "Interior1",
                table: "BoatAdditional");

            migrationBuilder.DropColumn(
                name: "Interior2",
                table: "BoatAdditional");

            migrationBuilder.DropColumn(
                name: "Interior3",
                table: "BoatAdditional");

            migrationBuilder.DropColumn(
                name: "Interior4",
                table: "BoatAdditional");

            migrationBuilder.DropColumn(
                name: "Other1",
                table: "BoatAdditional");

            migrationBuilder.DropColumn(
                name: "Other2",
                table: "BoatAdditional");
        }
    }
}
