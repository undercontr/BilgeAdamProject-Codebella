using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Codebella.WebUI.Migrations
{
    public partial class AnonLikeSupport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverImage",
                table: "Articles");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Likes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Likes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoverImage",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
