using Microsoft.EntityFrameworkCore.Migrations;

namespace PMISBLayer.Migrations
{
    public partial class AddFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInvoice",
                table: "PaymentTerms",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInvoice",
                table: "PaymentTerms");
        }
    }
}
