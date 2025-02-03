using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlgoaVehicleTraders.Data.Migrations
{
    /// <inheritdoc />
    public partial class CaravanImagesModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MultiRoon",
                table: "CaravanAdditional",
                newName: "MultiRoom");

            migrationBuilder.AddColumn<byte[]>(
                name: "Exterior1",
                table: "CaravanAdditional",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Exterior2",
                table: "CaravanAdditional",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Exterior3",
                table: "CaravanAdditional",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Exterior4",
                table: "CaravanAdditional",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Exterior5",
                table: "CaravanAdditional",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Exterior6",
                table: "CaravanAdditional",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Interior1",
                table: "CaravanAdditional",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Interior2",
                table: "CaravanAdditional",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Interior3",
                table: "CaravanAdditional",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Interior4",
                table: "CaravanAdditional",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Other1",
                table: "CaravanAdditional",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Other2",
                table: "CaravanAdditional",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Exterior1",
                table: "CaravanAdditional");

            migrationBuilder.DropColumn(
                name: "Exterior2",
                table: "CaravanAdditional");

            migrationBuilder.DropColumn(
                name: "Exterior3",
                table: "CaravanAdditional");

            migrationBuilder.DropColumn(
                name: "Exterior4",
                table: "CaravanAdditional");

            migrationBuilder.DropColumn(
                name: "Exterior5",
                table: "CaravanAdditional");

            migrationBuilder.DropColumn(
                name: "Exterior6",
                table: "CaravanAdditional");

            migrationBuilder.DropColumn(
                name: "Interior1",
                table: "CaravanAdditional");

            migrationBuilder.DropColumn(
                name: "Interior2",
                table: "CaravanAdditional");

            migrationBuilder.DropColumn(
                name: "Interior3",
                table: "CaravanAdditional");

            migrationBuilder.DropColumn(
                name: "Interior4",
                table: "CaravanAdditional");

            migrationBuilder.DropColumn(
                name: "Other1",
                table: "CaravanAdditional");

            migrationBuilder.DropColumn(
                name: "Other2",
                table: "CaravanAdditional");

            migrationBuilder.RenameColumn(
                name: "MultiRoom",
                table: "CaravanAdditional",
                newName: "MultiRoon");
        }
    }
}
