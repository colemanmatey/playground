using MoviesApp.Application.Interfaces;
using MoviesApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Application.Services
{
    public class MovieService
    {
        private readonly IMovieRepository _repository;
        public MovieService(IMovieRepository repository) {
            _repository = repository;
        }

        public List<Movie> GetAllMovies()
        {
            return _repository.GetAll();
        }
    }
}
