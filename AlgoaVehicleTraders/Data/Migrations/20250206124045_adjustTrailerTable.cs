using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlgoaVehicleTraders.Data.Migrations
{
    /// <inheritdoc />
    public partial class adjustTrailerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Trailer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StatusChangeDate",
                table: "Trailer",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Trailer");

            migrationBuilder.DropColumn(
                name: "StatusChangeDate",
                table: "Trailer");
        }
    }
}
