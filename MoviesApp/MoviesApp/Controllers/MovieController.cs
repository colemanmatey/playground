using Microsoft.AspNetCore.Mvc;
using MoviesApp.Application.Interfaces;
using MoviesApp.Application.Services;
using MoviesApp.Domain.Entities;

namespace MoviesApp.Web.Controllers
{
    public class MovieController : Controller
    {

        private readonly MovieService _service;

        public MovieController(MovieService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            List<Movie> movies = _service.GetAllMovies();
            return View(movies);
        }
    }
}
