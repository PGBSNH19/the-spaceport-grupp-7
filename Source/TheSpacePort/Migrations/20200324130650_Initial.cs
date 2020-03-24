using Microsoft.EntityFrameworkCore.Migrations;

namespace TheSpacePort.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "parkings",
                columns: table => new
                {
                    ParkingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleID = table.Column<int>(nullable: false),
                    ParkingCost = table.Column<int>(nullable: false),
                    ParkingSpaceLength = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parkings", x => x.ParkingID);
                });

            migrationBuilder.CreateTable(
                name: "people",
                columns: table => new
                {
                    PersonID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Height = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_people", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "spacePorts",
                columns: table => new
                {
                    SpacePortID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsOpen = table.Column<bool>(nullable: false),
                    AvailableParking = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spacePorts", x => x.SpacePortID);
                });

            migrationBuilder.CreateTable(
                name: "vehicles",
                columns: table => new
                {
                    VehicleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Length = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PersonID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicles", x => x.VehicleID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "parkings");

            migrationBuilder.DropTable(
                name: "people");

            migrationBuilder.DropTable(
                name: "spacePorts");

            migrationBuilder.DropTable(
                name: "vehicles");
        }
    }
}
