using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tap.az.Migrations
{
    public partial class addCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Elans");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Elans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Elans_CityId",
                table: "Elans",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Elans_City_CityId",
                table: "Elans",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elans_City_CityId",
                table: "Elans");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropIndex(
                name: "IX_Elans_CityId",
                table: "Elans");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Elans");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Elans",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: false,
                defaultValue: "");
        }
    }
}
