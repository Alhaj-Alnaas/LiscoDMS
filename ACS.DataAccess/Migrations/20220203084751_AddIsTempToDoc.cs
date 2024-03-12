using Microsoft.EntityFrameworkCore.Migrations;

namespace ACS.DataAccess.Migrations
{
    public partial class AddIsTempToDoc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTemp",
                table: "Docements",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTemp",
                table: "Docements");
        }
    }
}
