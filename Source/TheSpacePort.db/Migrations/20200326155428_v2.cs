using Microsoft.EntityFrameworkCore.Migrations;

namespace TheSpacePort.db.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_persons_starships_StarshipID",
                table: "persons");

            migrationBuilder.DropColumn(
                name: "StartshipID",
                table: "persons");

            migrationBuilder.AlterColumn<int>(
                name: "StarshipID",
                table: "persons",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_persons_starships_StarshipID",
                table: "persons",
                column: "StarshipID",
                principalTable: "starships",
                principalColumn: "StarshipID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_persons_starships_StarshipID",
                table: "persons");

            migrationBuilder.AlterColumn<int>(
                name: "StarshipID",
                table: "persons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "StartshipID",
                table: "persons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_persons_starships_StarshipID",
                table: "persons",
                column: "StarshipID",
                principalTable: "starships",
                principalColumn: "StarshipID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
