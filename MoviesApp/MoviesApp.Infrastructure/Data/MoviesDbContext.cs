using Microsoft.EntityFrameworkCore;
using MoviesApp.Domain.Entities;
using MoviesApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Infrastructure.Data
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options)
        {      
        }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>()
                .Property(m => m.Genre)
                .HasConversion<int>();

            // seed data
            modelBuilder.Entity<Movie>()
                .ToTable("Movie")
                .HasData(
                    new Movie { Id = 1, Name = "Inception", Year = 2010, Genre = Genre.SciFi, Rating = 9 },
                    new Movie { Id = 2, Name = "The Dark Knight", Year = 2008, Genre = Genre.Action, Rating = 10 },
                    new Movie { Id = 3, Name = "Interstellar", Year = 2014, Genre = Genre.SciFi, Rating = 9 },
                    new Movie { Id = 4, Name = "Titanic", Year = 1997, Genre = Genre.Romance, Rating = 8 },
                    new Movie { Id = 5, Name = "The Matrix", Year = 1999, Genre = Genre.SciFi, Rating = 9 },
                    new Movie { Id = 6, Name = "Avatar", Year = 2009, Genre = Genre.Adventure, Rating = 8 },
                    new Movie { Id = 7, Name = "Gladiator", Year = 2000, Genre = Genre.Action, Rating = 9 },
                    new Movie { Id = 8, Name = "The Godfather", Year = 1972, Genre = Genre.Crime, Rating = 10 },
                    new Movie { Id = 9, Name = "Shawshank Redemption", Year = 1994, Genre = Genre.Crime, Rating = 10 },
                    new Movie { Id = 10, Name = "Forrest Gump", Year = 1994, Genre = Genre.Drama, Rating = 9 },
                    new Movie { Id = 11, Name = "The Lion King", Year = 1994, Genre = Genre.Animation, Rating = 8 },
                    new Movie { Id = 12, Name = "Avengers: Endgame", Year = 2019, Genre = Genre.Action, Rating = 9 },
                    new Movie { Id = 13, Name = "Parasite", Year = 2019, Genre = Genre.Thriller, Rating = 9 },
                    new Movie { Id = 14, Name = "Joker", Year = 2019, Genre = Genre.Crime, Rating = 8 },
                    new Movie { Id = 15, Name = "Frozen", Year = 2013, Genre = Genre.Musical, Rating = 7 },
                    new Movie { Id = 16, Name = "The Silence of the Lambs", Year = 1991, Genre = Genre.Horror, Rating = 9 },
                    new Movie { Id = 17, Name = "The Grand Budapest Hotel", Year = 2014, Genre = Genre.Comedy, Rating = 8 },
                    new Movie { Id = 18, Name = "Spider-Man: No Way Home", Year = 2021, Genre = Genre.Action, Rating = 9 },
                    new Movie { Id = 19, Name = "Whiplash", Year = 2014, Genre = Genre.Musical, Rating = 9 },
                    new Movie { Id = 20, Name = "Mad Max: Fury Road", Year = 2015, Genre = Genre.Action, Rating = 9 }
                );
        }

    }
}
