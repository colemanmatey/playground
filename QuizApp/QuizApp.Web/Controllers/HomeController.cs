using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Application.Services;
using QuizApp.Web.Models;

namespace QuizApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly QuizService _quizservice;

    public HomeController(ILogger<HomeController> logger, QuizService quizService)
    {
        _logger = logger;
        _quizservice = quizService;
    }

    public IActionResult Index()
    {
        QuizViewModel model = new QuizViewModel();
        model.quizzes = _quizservice.GetAllQuizzes();
        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
