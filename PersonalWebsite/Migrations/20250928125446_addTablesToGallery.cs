using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaqiaPortFolio.Migrations
{
    /// <inheritdoc />
    public partial class addTablesToGallery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Photo",
                table: "Gallery",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Gallery",
                newName: "Imagepath");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Gallery",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GitHubUrl",
                table: "Gallery",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Gallery");

            migrationBuilder.DropColumn(
                name: "GitHubUrl",
                table: "Gallery");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Gallery",
                newName: "Photo");

            migrationBuilder.RenameColumn(
                name: "Imagepath",
                table: "Gallery",
                newName: "Category");
        }
    }
}
