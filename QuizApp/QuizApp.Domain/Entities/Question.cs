using QuizApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Domain.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public required string QuestionText { get; set; }
        public QuestionType QuestionType { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
        public List<Choice> Choices { get; set; } = new List<Choice>();

        // Navigational property
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; } = null!;
    }
}
