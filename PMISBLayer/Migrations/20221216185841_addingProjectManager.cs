using Microsoft.EntityFrameworkCore.Migrations;

namespace PMISBLayer.Migrations
{
    public partial class addingProjectManager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProjectManagerId",
                table: "Projects",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectManagerId",
                table: "Projects",
                column: "ProjectManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_ProjectManagerId",
                table: "Projects",
                column: "ProjectManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_ProjectManagerId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ProjectManagerId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectManagerId",
                table: "Projects");
        }
    }
}
