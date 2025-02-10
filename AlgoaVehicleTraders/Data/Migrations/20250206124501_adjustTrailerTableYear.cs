using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlgoaVehicleTraders.Data.Migrations
{
    /// <inheritdoc />
    public partial class adjustTrailerTableYear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Trailer",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "Trailer");
        }
    }
}
