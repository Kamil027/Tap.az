using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tap.az.Migrations
{
    public partial class addAppUserinElan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Elans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "Elans",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Elans_AppUserId1",
                table: "Elans",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Elans_AspNetUsers_AppUserId1",
                table: "Elans",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elans_AspNetUsers_AppUserId1",
                table: "Elans");

            migrationBuilder.DropIndex(
                name: "IX_Elans_AppUserId1",
                table: "Elans");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Elans");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "Elans");
        }
    }
}
