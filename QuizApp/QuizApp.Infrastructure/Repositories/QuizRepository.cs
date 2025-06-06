﻿using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Interfaces;
using QuizApp.Domain.Entities;
using QuizApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Infrastructure.Repositories
{
    public class QuizRepository : IQuizRepository
    {
        private readonly QuizDbContext _context;

        public QuizRepository(QuizDbContext context)
        {
            _context = context;
        }

        public List<Quiz> GetAll()
        {
            return _context.Quizzes.ToList();
        }

        public Quiz GetById(int id)
        {
            var quiz = _context.Quizzes
                .Include(quiz => quiz.Questions)
                    .ThenInclude(question => question.Choices)
                .SingleOrDefault(quiz => quiz.Id == id);

            if (quiz == null)
            {
                throw new KeyNotFoundException($"Quiz with ID {id} not found.");
            }
            return quiz;
        }
    }
}
