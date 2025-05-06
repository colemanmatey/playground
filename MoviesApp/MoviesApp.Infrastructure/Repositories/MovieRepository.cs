using MoviesApp.Application.Interfaces;
using MoviesApp.Domain.Entities;
using MoviesApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MoviesDbContext _context;

        public MovieRepository(MoviesDbContext context)
        {
            _context = context;
        }
        public List<Movie> GetAll()
        {
            List<Movie> movies = _context.Movies.ToList();     
            return movies;
        }
    }
}
