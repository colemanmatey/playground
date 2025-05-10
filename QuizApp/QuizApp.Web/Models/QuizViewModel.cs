using QuizApp.Domain.Entities;

namespace QuizApp.Web.Models
{
    public class QuizViewModel
    {
        public List<Quiz>? Quizzes;
        public Quiz? Quiz { get; set; }
    }
}
