using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FurnitureHub.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "productCategories",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "productCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "productCategories");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "productCategories",
                newName: "ID");
        }
    }
}
