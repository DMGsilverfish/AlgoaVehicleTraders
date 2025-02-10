using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlgoaVehicleTraders.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTrailerTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AxleType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AxleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AxleType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BrakedAxle",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrakedAxleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrakedAxle", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CampTrailer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrailerID = table.Column<int>(type: "int", nullable: false),
                    KitchesHas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sleeper = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpareTyre = table.Column<bool>(type: "bit", nullable: false),
                    Awning = table.Column<bool>(type: "bit", nullable: false),
                    Tent = table.Column<bool>(type: "bit", nullable: false),
                    Geyser = table.Column<bool>(type: "bit", nullable: false),
                    WaterTank = table.Column<bool>(type: "bit", nullable: false),
                    WaterPump = table.Column<bool>(type: "bit", nullable: false),
                    VoltPowerSupply_12 = table.Column<bool>(type: "bit", nullable: false),
                    VoltPowerSupplt_220 = table.Column<bool>(type: "bit", nullable: false),
                    Battery = table.Column<bool>(type: "bit", nullable: false),
                    ChargeSystem = table.Column<bool>(type: "bit", nullable: false),
                    Add_A_Room = table.Column<bool>(type: "bit", nullable: false),
                    GasBottles = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampTrailer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Trailer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    AxleType = table.Column<int>(type: "int", nullable: false),
                    BrakedAxle = table.Column<int>(type: "int", nullable: false),
                    NumberAxle = table.Column<int>(type: "int", nullable: false),
                    TyreSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Length = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Exterior1 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Exterior2 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Exterior3 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Exterior4 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Exterior5 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Exterior6 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Interior1 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Interior2 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Interior3 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Interior4 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Interior5 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Interior6 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Other1 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Other2 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trailer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TrailerBrand",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrailerBrand", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TrailerType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrailerType", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AxleType");

            migrationBuilder.DropTable(
                name: "BrakedAxle");

            migrationBuilder.DropTable(
                name: "CampTrailer");

            migrationBuilder.DropTable(
                name: "Trailer");

            migrationBuilder.DropTable(
                name: "TrailerBrand");

            migrationBuilder.DropTable(
                name: "TrailerType");
        }
    }
}
