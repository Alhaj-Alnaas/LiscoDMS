using Microsoft.EntityFrameworkCore.Migrations;

namespace ACS.DataAccess.Migrations
{
    public partial class NewMigration2022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DaysToReplay",
                table: "Packages",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DaysToReplay",
                table: "Packages");
        }
    }
}
