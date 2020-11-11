using Microsoft.EntityFrameworkCore.Migrations;

namespace TogevaAPI2.Migrations
{
    public partial class sport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "sport",
                table: "Announces",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sport",
                table: "Announces");
        }
    }
}
