using Microsoft.EntityFrameworkCore.Migrations;

namespace PMISBLayer.Migrations
{
    public partial class obida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Invoices",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ProjectId",
                table: "Invoices",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Projects_ProjectId",
                table: "Invoices",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Projects_ProjectId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_ProjectId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Invoices");
        }
    }
}
