using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACS.DataAccess.Migrations
{
    public partial class addspmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_AspNetUsers_CreatedById",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_AspNetUsers_DeletedById",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_AspNetUsers_LastUpdatedById",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_AspNetUsers_UserId",
                table: "Feedback");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feedback",
                table: "Feedback");

            migrationBuilder.RenameTable(
                name: "Feedback",
                newName: "Feedbacks");

            migrationBuilder.RenameIndex(
                name: "IX_Feedback_UserId",
                table: "Feedbacks",
                newName: "IX_Feedbacks_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Feedback_LastUpdatedById",
                table: "Feedbacks",
                newName: "IX_Feedbacks_LastUpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Feedback_DeletedById",
                table: "Feedbacks",
                newName: "IX_Feedbacks_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_Feedback_CreatedById",
                table: "Feedbacks",
                newName: "IX_Feedbacks_CreatedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CollectingMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SerialNumber = table.Column<string>(nullable: true),
                    SenderId = table.Column<string>(nullable: true),
                    SenderDiscription = table.Column<string>(nullable: true),
                    passedBy = table.Column<string>(nullable: true),
                    RecipintDiscription = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsReaded = table.Column<bool>(nullable: false),
                    IsReplyed = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    OriginalBody = table.Column<string>(nullable: true),
                    OriginMessageId = table.Column<string>(nullable: true),
                    IsOrigin = table.Column<bool>(nullable: false),
                    SendingDateTime = table.Column<DateTime>(nullable: false),
                    MessageFrom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectingMessages", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_AspNetUsers_CreatedById",
                table: "Feedbacks",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_AspNetUsers_DeletedById",
                table: "Feedbacks",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_AspNetUsers_LastUpdatedById",
                table: "Feedbacks",
                column: "LastUpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_AspNetUsers_UserId",
                table: "Feedbacks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_AspNetUsers_CreatedById",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_AspNetUsers_DeletedById",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_AspNetUsers_LastUpdatedById",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_AspNetUsers_UserId",
                table: "Feedbacks");

            migrationBuilder.DropTable(
                name: "CollectingMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks");

            migrationBuilder.RenameTable(
                name: "Feedbacks",
                newName: "Feedback");

            migrationBuilder.RenameIndex(
                name: "IX_Feedbacks_UserId",
                table: "Feedback",
                newName: "IX_Feedback_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Feedbacks_LastUpdatedById",
                table: "Feedback",
                newName: "IX_Feedback_LastUpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Feedbacks_DeletedById",
                table: "Feedback",
                newName: "IX_Feedback_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_Feedbacks_CreatedById",
                table: "Feedback",
                newName: "IX_Feedback_CreatedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feedback",
                table: "Feedback",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_AspNetUsers_CreatedById",
                table: "Feedback",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_AspNetUsers_DeletedById",
                table: "Feedback",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_AspNetUsers_LastUpdatedById",
                table: "Feedback",
                column: "LastUpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_AspNetUsers_UserId",
                table: "Feedback",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
