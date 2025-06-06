﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Domain.Entities
{
    public class Choice
    {
        public int Id { get; set; }
        public required string ChoiceText { get; set; }

        // Navigational Property
        public int QuestionId { get; set; }
        public Question Question { get; set; } = null!;

    }
}
