using QuizApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Application.Interfaces
{
    public interface IQuizRepository
    {
        List<Quiz> GetQuizzes();
    }
}
