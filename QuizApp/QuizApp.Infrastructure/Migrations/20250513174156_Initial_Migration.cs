using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quiz",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quiz", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionType = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuizId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_Quiz_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quiz",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Choices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChoiceText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Choices_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Quiz",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 13, 13, 41, 55, 523, DateTimeKind.Local).AddTicks(6899), "Admin", "Test your general knowledge with these questions!", "General Knowledge Quiz", new DateTime(2025, 5, 13, 13, 41, 55, 523, DateTimeKind.Local).AddTicks(6903) },
                    { 2, new DateTime(2025, 5, 13, 13, 41, 55, 523, DateTimeKind.Local).AddTicks(6910), "Admin", "A set of questions covering basic scientific concepts.", "Science Quiz", new DateTime(2025, 5, 13, 13, 41, 55, 523, DateTimeKind.Local).AddTicks(6913) }
                });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "CreatedAt", "QuestionText", "QuestionType", "QuizId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 13, 17, 41, 55, 523, DateTimeKind.Utc).AddTicks(7200), "What is the capital of France?", 0, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2025, 5, 13, 17, 41, 55, 523, DateTimeKind.Utc).AddTicks(7204), "Which planet is known as the Red Planet?", 0, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2025, 5, 13, 17, 41, 55, 523, DateTimeKind.Utc).AddTicks(7206), "Who wrote 'Romeo and Juliet'?", 0, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2025, 5, 13, 17, 41, 55, 523, DateTimeKind.Utc).AddTicks(7208), "What is the chemical symbol for water?", 0, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2025, 5, 13, 17, 41, 55, 523, DateTimeKind.Utc).AddTicks(7210), "Which country is known as the Land of the Rising Sun?", 0, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Choices",
                columns: new[] { "Id", "ChoiceText", "QuestionId" },
                values: new object[,]
                {
                    { 1, "Paris", 1 },
                    { 2, "London", 1 },
                    { 3, "Berlin", 1 },
                    { 4, "Madrid", 1 },
                    { 5, "Mars", 2 },
                    { 6, "Jupiter", 2 },
                    { 7, "Saturn", 2 },
                    { 8, "Venus", 2 },
                    { 9, "Shakespeare", 3 },
                    { 10, "Dickens", 3 },
                    { 11, "Hemingway", 3 },
                    { 12, "Austen", 3 },
                    { 13, "H2O", 4 },
                    { 14, "CO2", 4 },
                    { 15, "O2", 4 },
                    { 16, "NaCl", 4 },
                    { 17, "Japan", 5 },
                    { 18, "China", 5 },
                    { 19, "South Korea", 5 },
                    { 20, "Thailand", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Choices_QuestionId",
                table: "Choices",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_QuizId",
                table: "Question",
                column: "QuizId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Choices");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Quiz");
        }
    }
}
