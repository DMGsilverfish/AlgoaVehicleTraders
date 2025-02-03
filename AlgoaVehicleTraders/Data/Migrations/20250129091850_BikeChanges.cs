using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlgoaVehicleTraders.Data.Migrations
{
    /// <inheritdoc />
    public partial class BikeChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AC",
                table: "BikeAdditional");

            migrationBuilder.DropColumn(
                name: "FullServiceHistory",
                table: "BikeAdditional");

            migrationBuilder.RenameColumn(
                name: "Radio",
                table: "BikeAdditional",
                newName: "CenterStand");

            migrationBuilder.AlterColumn<string>(
                name: "Condition",
                table: "Bike",
                type: "VARCHAR(MAX)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CenterStand",
                table: "BikeAdditional",
                newName: "Radio");

            migrationBuilder.AddColumn<bool>(
                name: "AC",
                table: "BikeAdditional",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FullServiceHistory",
                table: "BikeAdditional",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Condition",
                table: "Bike",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(MAX)");
        }
    }
}
