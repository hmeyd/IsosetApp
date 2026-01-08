using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoMvcApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "Prix");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "Reference");

            migrationBuilder.AddColumn<string>(
                name: "Categorie",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAjout",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModification",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Nom",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Quantite",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categorie",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DateAjout",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DateModification",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Nom",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Quantite",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Reference",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Prix",
                table: "Products",
                newName: "Price");
        }
    }
}
