using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlgoaVehicleTraders.Data.Migrations
{
    /// <inheritdoc />
    public partial class AwningChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Awning",
                table: "Caravan");

            migrationBuilder.AddColumn<bool>(
                name: "Awning",
                table: "CaravanAdditional",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Awning",
                table: "CaravanAdditional");

            migrationBuilder.AddColumn<int>(
                name: "Awning",
                table: "Caravan",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
