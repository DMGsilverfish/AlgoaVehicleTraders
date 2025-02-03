using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlgoaVehicleTraders.Data.Migrations
{
    /// <inheritdoc />
    public partial class BikeAndBoatTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EngineSize",
                table: "Boat");

            migrationBuilder.RenameColumn(
                name: "DriveTrain",
                table: "Boat",
                newName: "Engine");

            migrationBuilder.AddColumn<int>(
                name: "ConsoleLocation",
                table: "Boat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BikeAdditional",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BikeID = table.Column<int>(type: "int", nullable: false),
                    Radio = table.Column<bool>(type: "bit", nullable: false),
                    TopBox = table.Column<bool>(type: "bit", nullable: false),
                    Panniers = table.Column<bool>(type: "bit", nullable: false),
                    RaisedScreen = table.Column<bool>(type: "bit", nullable: false),
                    HeatedGrips = table.Column<bool>(type: "bit", nullable: false),
                    AC = table.Column<bool>(type: "bit", nullable: false),
                    FullServiceHistory = table.Column<bool>(type: "bit", nullable: false),
                    OffRoadCapable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BikeAdditional", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BoatAdditional",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoatID = table.Column<int>(type: "int", nullable: false),
                    WaterDepth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisteredTrailer = table.Column<bool>(type: "bit", nullable: false),
                    FishFinder = table.Column<bool>(type: "bit", nullable: false),
                    LifeJackets = table.Column<bool>(type: "bit", nullable: false),
                    SafetyEquipment = table.Column<bool>(type: "bit", nullable: false),
                    VhfRadio = table.Column<bool>(type: "bit", nullable: false),
                    SkiTower = table.Column<bool>(type: "bit", nullable: false),
                    COF = table.Column<bool>(type: "bit", nullable: false),
                    BuoyancyCertificate = table.Column<bool>(type: "bit", nullable: false),
                    LiveWell = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoatAdditional", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BikeAdditional");

            migrationBuilder.DropTable(
                name: "BoatAdditional");

            migrationBuilder.DropColumn(
                name: "ConsoleLocation",
                table: "Boat");

            migrationBuilder.RenameColumn(
                name: "Engine",
                table: "Boat",
                newName: "DriveTrain");

            migrationBuilder.AddColumn<string>(
                name: "EngineSize",
                table: "Boat",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
