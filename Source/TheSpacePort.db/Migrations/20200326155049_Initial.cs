using Microsoft.EntityFrameworkCore.Migrations;

namespace TheSpacePort.db.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "starships",
                columns: table => new
                {
                    StarshipID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Length = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_starships", x => x.StarshipID);
                });

            migrationBuilder.CreateTable(
                name: "parkings",
                columns: table => new
                {
                    ParkingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParkingCost = table.Column<int>(nullable: false),
                    ParkingSpaceLength = table.Column<int>(nullable: false),
                    StarshipID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parkings", x => x.ParkingID);
                    table.ForeignKey(
                        name: "FK_parkings_starships_StarshipID",
                        column: x => x.StarshipID,
                        principalTable: "starships",
                        principalColumn: "StarshipID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "persons",
                columns: table => new
                {
                    PersonID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    StarshipID = table.Column<int>(nullable: true),
                    StartshipID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persons", x => x.PersonID);
                    table.ForeignKey(
                        name: "FK_persons_starships_StarshipID",
                        column: x => x.StarshipID,
                        principalTable: "starships",
                        principalColumn: "StarshipID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_parkings_StarshipID",
                table: "parkings",
                column: "StarshipID");

            migrationBuilder.CreateIndex(
                name: "IX_persons_StarshipID",
                table: "persons",
                column: "StarshipID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "parkings");

            migrationBuilder.DropTable(
                name: "persons");

            migrationBuilder.DropTable(
                name: "starships");
        }
    }
}
