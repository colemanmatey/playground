using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BPTracker.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Readings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Systolic = table.Column<int>(type: "int", nullable: false),
                    Diastolic = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Readings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Readings",
                columns: new[] { "Id", "Date", "Diastolic", "Systolic" },
                values: new object[,]
                {
                    { 1, new DateOnly(2021, 10, 1), 80, 120 },
                    { 2, new DateOnly(2021, 10, 2), 90, 130 },
                    { 3, new DateOnly(2021, 10, 3), 100, 140 },
                    { 4, new DateOnly(2021, 10, 4), 110, 150 },
                    { 5, new DateOnly(2021, 10, 5), 120, 160 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Readings");
        }
    }
}
