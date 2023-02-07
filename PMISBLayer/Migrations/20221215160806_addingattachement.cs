using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PMISBLayer.Migrations
{
    public partial class addingattachement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ContractFile",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContractFileName",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContractFileType",
                table: "Projects",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContractFile",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ContractFileName",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ContractFileType",
                table: "Projects");
        }
    }
}
