using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tap.az.Migrations
{
    public partial class ll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elans_Categorys_CategoryId",
                table: "Elans");

            migrationBuilder.DropIndex(
                name: "IX_Elans_CategoryId",
                table: "Elans");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Elans");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Elans",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Elans",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(45)",
                oldMaxLength: 45);

            migrationBuilder.AlterColumn<string>(
                name: "ElanName",
                table: "Elans",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(45)",
                oldMaxLength: 45);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Elans",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<int>(
                name: "CinsId",
                table: "Elans",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MalinNovuId",
                table: "Elans",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "Elans",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Elans_CinsId",
                table: "Elans",
                column: "CinsId");

            migrationBuilder.CreateIndex(
                name: "IX_Elans_MalinNovuId",
                table: "Elans",
                column: "MalinNovuId");

            migrationBuilder.CreateIndex(
                name: "IX_Elans_ModelId",
                table: "Elans",
                column: "ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Elans_Cinses_CinsId",
                table: "Elans",
                column: "CinsId",
                principalTable: "Cinses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Elans_MalinNovleri_MalinNovuId",
                table: "Elans",
                column: "MalinNovuId",
                principalTable: "MalinNovleri",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Elans_Models_ModelId",
                table: "Elans",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elans_Cinses_CinsId",
                table: "Elans");

            migrationBuilder.DropForeignKey(
                name: "FK_Elans_MalinNovleri_MalinNovuId",
                table: "Elans");

            migrationBuilder.DropForeignKey(
                name: "FK_Elans_Models_ModelId",
                table: "Elans");

            migrationBuilder.DropIndex(
                name: "IX_Elans_CinsId",
                table: "Elans");

            migrationBuilder.DropIndex(
                name: "IX_Elans_MalinNovuId",
                table: "Elans");

            migrationBuilder.DropIndex(
                name: "IX_Elans_ModelId",
                table: "Elans");

            migrationBuilder.DropColumn(
                name: "CinsId",
                table: "Elans");

            migrationBuilder.DropColumn(
                name: "MalinNovuId",
                table: "Elans");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Elans");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Elans",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Elans",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "ElanName",
                table: "Elans",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Elans",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Elans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Elans_CategoryId",
                table: "Elans",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Elans_Categorys_CategoryId",
                table: "Elans",
                column: "CategoryId",
                principalTable: "Categorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
