using QuizApp.Application.Interfaces;
using QuizApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Application.Services
{
    public class QuizService
    {
        private readonly IQuizRepository _quizRepository;

        public QuizService(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;   
        }

        public List<Quiz> GetAllQuizzes()
        {
            return _quizRepository.GetAll();
        }
    }
}
