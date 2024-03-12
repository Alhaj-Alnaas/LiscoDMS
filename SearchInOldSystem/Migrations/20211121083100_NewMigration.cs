using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SearchInOldSystem.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    LTR_NO = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ESHRY_NO = table.Column<string>(maxLength: 50, nullable: true),
                    ENTER_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    LTR_DES = table.Column<string>(maxLength: 150, nullable: true),
                    wplac_recno = table.Column<double>(nullable: true),
                    wplac_expno = table.Column<double>(nullable: true),
                    photo = table.Column<byte[]>(type: "image", nullable: true),
                    ltr_year = table.Column<int>(nullable: true),
                    SLTR_NO = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "POST_SENDR",
                columns: table => new
                {
                    LATER_no = table.Column<double>(nullable: true),
                    LTR_TYPE = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    ENTER_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    OUT_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    RECORD_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    TRNSLAT_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    WPLAC_recl = table.Column<string>(maxLength: 50, nullable: true),
                    WPLAC_recno = table.Column<string>(nullable: true),
                    WPLAC_expl = table.Column<string>(maxLength: 50, nullable: true),
                    WPLAC_expno = table.Column<string>(nullable: true),
                    WPLAC_trnno = table.Column<double>(nullable: true),
                    LATER_infor = table.Column<string>(maxLength: 200, nullable: true),
                    POST_typel = table.Column<string>(maxLength: 50, nullable: true),
                    POST_typeno = table.Column<double>(nullable: true),
                    RECORD_namel = table.Column<string>(maxLength: 50, nullable: true),
                    RECORD_nameno = table.Column<double>(nullable: true),
                    PLACEOUT_rec = table.Column<string>(maxLength: 80, nullable: true),
                    PLACEOUT_placer = table.Column<string>(maxLength: 80, nullable: true),
                    RECIV_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    FILNO_APPEND = table.Column<double>(nullable: true),
                    RECIVE_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    FLAGE_SD = table.Column<double>(nullable: true),
                    ltr_year = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "POST_SENDR");
        }
    }
}
