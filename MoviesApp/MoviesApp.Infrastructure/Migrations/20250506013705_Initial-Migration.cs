using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MoviesApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "Genre", "Name", "Rating", "Year" },
                values: new object[,]
                {
                    { 1, 12, "Inception", 9, 2010 },
                    { 2, 0, "The Dark Knight", 10, 2008 },
                    { 3, 12, "Interstellar", 9, 2014 },
                    { 4, 11, "Titanic", 8, 1997 },
                    { 5, 12, "The Matrix", 9, 1999 },
                    { 6, 2, "Avatar", 8, 2009 },
                    { 7, 0, "Gladiator", 9, 2000 },
                    { 8, 4, "The Godfather", 10, 1972 },
                    { 9, 4, "Shawshank Redemption", 10, 1994 },
                    { 10, 6, "Forrest Gump", 9, 1994 },
                    { 11, 1, "The Lion King", 8, 1994 },
                    { 12, 0, "Avengers: Endgame", 9, 2019 },
                    { 13, 13, "Parasite", 9, 2019 },
                    { 14, 4, "Joker", 8, 2019 },
                    { 15, 9, "Frozen", 7, 2013 },
                    { 16, 8, "The Silence of the Lambs", 9, 1991 },
                    { 17, 3, "The Grand Budapest Hotel", 8, 2014 },
                    { 18, 0, "Spider-Man: No Way Home", 9, 2021 },
                    { 19, 9, "Whiplash", 9, 2014 },
                    { 20, 0, "Mad Max: Fury Road", 9, 2015 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}
