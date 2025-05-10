using Microsoft.AspNetCore.Mvc;
using QuizApp.Application.Services;
using QuizApp.Web.Models;

namespace QuizApp.Web.Controllers
{
    public class QuizController : Controller
    {
        private readonly QuizService _quizService;
        public QuizController(QuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpGet]
        [Route("quizzes/all/{id}")]
        public IActionResult Index(int id)
        {
            QuizViewModel model = new QuizViewModel();
            model.Quiz = _quizService.GetQuizById(id);
            
            return View("Quiz", model);
        }
    }
}
