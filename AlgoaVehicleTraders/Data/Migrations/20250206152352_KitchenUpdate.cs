using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlgoaVehicleTraders.Data.Migrations
{
    /// <inheritdoc />
    public partial class KitchenUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KitchesHas",
                table: "CampTrailer",
                newName: "KitchenHas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KitchenHas",
                table: "CampTrailer",
                newName: "KitchesHas");
        }
    }
}
