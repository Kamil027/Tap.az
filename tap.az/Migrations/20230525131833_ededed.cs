using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tap.az.Migrations
{
    public partial class ededed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elans_AspNetUsers_AppUserId1",
                table: "Elans");

            migrationBuilder.DropIndex(
                name: "IX_Elans_AppUserId1",
                table: "Elans");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "Elans");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Elans",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Elans_AppUserId",
                table: "Elans",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Elans_AspNetUsers_AppUserId",
                table: "Elans",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elans_AspNetUsers_AppUserId",
                table: "Elans");

            migrationBuilder.DropIndex(
                name: "IX_Elans_AppUserId",
                table: "Elans");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Elans",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
    }
}
