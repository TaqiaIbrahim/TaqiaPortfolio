using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaqiaPortFolio.Migrations
{
    /// <inheritdoc />
    public partial class addColumsToTraning : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Training",
                newName: "place");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Training",
                newName: "StartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Training",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Training",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Training");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Training");

            migrationBuilder.RenameColumn(
                name: "place",
                table: "Training",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Training",
                newName: "Date");
        }
    }
}
