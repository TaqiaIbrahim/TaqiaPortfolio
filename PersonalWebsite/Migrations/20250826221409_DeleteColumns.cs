using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaqiaPortFolio.Migrations
{
    /// <inheritdoc />
    public partial class DeleteColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Video",
                table: "Slider");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "AboutMe");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "AboutMe");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Video",
                table: "Slider",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "AboutMe",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Experience",
                table: "AboutMe",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
