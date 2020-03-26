using Microsoft.EntityFrameworkCore.Migrations;

namespace TheSpacePort.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "people",
                columns: table => new
                {
                    PersonID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
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
                    AvailableParking = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spacePorts", x => x.SpacePortID);
                });

            migrationBuilder.CreateTable(
                name: "starships",
                columns: table => new
                {
                    StarshipID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Length = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PersonID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_starships", x => x.StarshipID);
                    table.ForeignKey(
                        name: "FK_starships_people_PersonID",
                        column: x => x.PersonID,
                        principalTable: "people",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "parkings",
                columns: table => new
                {
                    ParkingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StarshipID = table.Column<int>(nullable: false),
                    ParkingCost = table.Column<int>(nullable: false),
                    ParkingSpaceLength = table.Column<int>(nullable: false),
                    SpacePortID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parkings", x => x.ParkingID);
                    table.ForeignKey(
                        name: "FK_parkings_spacePorts_SpacePortID",
                        column: x => x.SpacePortID,
                        principalTable: "spacePorts",
                        principalColumn: "SpacePortID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_parkings_SpacePortID",
                table: "parkings",
                column: "SpacePortID");

            migrationBuilder.CreateIndex(
                name: "IX_starships_PersonID",
                table: "starships",
                column: "PersonID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "parkings");

            migrationBuilder.DropTable(
                name: "starships");

            migrationBuilder.DropTable(
                name: "spacePorts");

            migrationBuilder.DropTable(
                name: "people");
        }
    }
}
