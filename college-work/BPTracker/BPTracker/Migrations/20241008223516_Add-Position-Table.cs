using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BPTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddPositionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PositionId",
                table: "Readings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "1", "Standing" },
                    { "2", "Sitting" },
                    { "3", "Lying down" }
                });

            migrationBuilder.UpdateData(
                table: "Readings",
                keyColumn: "Id",
                keyValue: 1,
                column: "PositionId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "Readings",
                keyColumn: "Id",
                keyValue: 2,
                column: "PositionId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "Readings",
                keyColumn: "Id",
                keyValue: 3,
                column: "PositionId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "Readings",
                keyColumn: "Id",
                keyValue: 4,
                column: "PositionId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "Readings",
                keyColumn: "Id",
                keyValue: 5,
                column: "PositionId",
                value: "2");

            migrationBuilder.CreateIndex(
                name: "IX_Readings_PositionId",
                table: "Readings",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Readings_Positions_PositionId",
                table: "Readings",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Readings_Positions_PositionId",
                table: "Readings");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Readings_PositionId",
                table: "Readings");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Readings");
        }
    }
}
