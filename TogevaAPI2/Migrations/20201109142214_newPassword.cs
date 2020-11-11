using Microsoft.EntityFrameworkCore.Migrations;

namespace TogevaAPI2.Migrations
{
    public partial class newPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "newPassword",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "newPassword",
                table: "Users");
        }
    }
}
