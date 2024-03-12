using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACS.DataAccess.Migrations
{
    public partial class AddIsArchiveUserColumMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsArchiveUser",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "SystemUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FileNumber = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    ResponsibilityCode = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    RespCodeId = table.Column<int>(nullable: false),
                    JobCatId = table.Column<int>(nullable: false),
                    JobStatus = table.Column<string>(nullable: true),
                    DesignationId = table.Column<int>(nullable: false),
                    JobtypeName = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUsers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemUsers");

            migrationBuilder.DropColumn(
                name: "IsArchiveUser",
                table: "AspNetUsers");
        }
    }
}
