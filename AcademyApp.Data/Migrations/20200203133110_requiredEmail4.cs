using Microsoft.EntityFrameworkCore.Migrations;

namespace AcademyApp.Data.Migrations
{
    public partial class requiredEmail4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAdress",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Users",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "EmailAdress",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }
    }
}
