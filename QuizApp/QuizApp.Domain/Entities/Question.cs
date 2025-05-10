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

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Choice> Choices { get; set; }

        // Navigational property
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }

        public Question()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Choices = new List<Choice>();
        }
        
        public Question(string question)
        {
            QuestionText = question;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Choices = new List<Choice>();
        }
        public Question(string question, QuestionType questionType)
        {
            QuestionText = question;
            QuestionType = questionType;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Choices = new List<Choice>();
        }
    }
}
