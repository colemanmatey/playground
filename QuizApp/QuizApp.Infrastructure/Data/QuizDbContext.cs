using Microsoft.EntityFrameworkCore;
using QuizApp.Domain.Entities;
using QuizApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Infrastructure.Data
{
    public class QuizDbContext : DbContext
    {
        public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options)
        {
        }

        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Choice> Choices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Quiz>()
                .ToTable("Quiz")
                .HasMany(q => q.Questions)
                .WithOne(x => x.Quiz);

            modelBuilder.Entity<Question>()
                .ToTable("Question")
                .HasMany(q => q.Choices)
                .WithOne(c => c.Question);
                

            // Seed Data
            modelBuilder.Entity<Quiz>()
                .HasData(
                    new Quiz
                    {
                        Id = 1,
                        Title = "General Knowledge Quiz",
                        Description = "Test your general knowledge with these questions!",
                        CreatedBy = "Admin",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    },
                    new Quiz
                    {
                        Id = 2,
                        Title = "Science Quiz",
                        Description = "A set of questions covering basic scientific concepts.",
                        CreatedBy = "Admin",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    }
                );

            modelBuilder.Entity<Question>()
                .HasData(
                    new Question 
                    { 
                        Id = 1, 
                        QuestionText = "What is the capital of France?", 
                        QuestionType = QuestionType.SingleChoice, 
                        QuizId = 1 
                    },
                    new Question 
                    { 
                        Id = 2, 
                        QuestionText = "Which planet is known as the Red Planet?", 
                        QuestionType = QuestionType.SingleChoice, 
                        QuizId = 1 
                    },
                    new Question 
                    { 
                        Id = 3, 
                        QuestionText = "Who wrote 'Romeo and Juliet'?",
                        QuestionType = QuestionType.SingleChoice, 
                        QuizId = 1 
                    },
                    new Question 
                    { 
                        Id = 4, 
                        QuestionText = "What is the chemical symbol for water?", 
                        QuestionType = QuestionType.SingleChoice, 
                        QuizId = 2 
                    },
                    new Question 
                    { 
                        Id = 5, 
                        QuestionText = "Which country is known as the Land of the Rising Sun?", 
                        QuestionType = QuestionType.SingleChoice, 
                        QuizId = 2 
                    }
                );

            modelBuilder.Entity<Choice>()
                .HasData(
                    new Choice { Id = 1, ChoiceText = "Paris", QuestionId = 1 },
                    new Choice { Id = 2, ChoiceText = "London", QuestionId = 1 },
                    new Choice { Id = 3, ChoiceText = "Berlin", QuestionId = 1 },
                    new Choice { Id = 4, ChoiceText = "Madrid", QuestionId = 1 },

                    new Choice { Id = 5, ChoiceText = "Mars", QuestionId = 2 },
                    new Choice { Id = 6, ChoiceText = "Jupiter", QuestionId = 2 },
                    new Choice { Id = 7, ChoiceText = "Saturn", QuestionId = 2 },
                    new Choice { Id = 8, ChoiceText = "Venus", QuestionId = 2 },

                    new Choice { Id = 9, ChoiceText = "Shakespeare", QuestionId = 3 },
                    new Choice { Id = 10, ChoiceText = "Dickens", QuestionId = 3 },
                    new Choice { Id = 11, ChoiceText = "Hemingway", QuestionId = 3 },
                    new Choice { Id = 12, ChoiceText = "Austen", QuestionId = 3 },

                    new Choice { Id = 13, ChoiceText = "H2O", QuestionId = 4 },
                    new Choice { Id = 14, ChoiceText = "CO2", QuestionId = 4 },
                    new Choice { Id = 15, ChoiceText = "O2", QuestionId = 4 },
                    new Choice { Id = 16, ChoiceText = "NaCl", QuestionId = 4 },

                    new Choice { Id = 17, ChoiceText = "Japan", QuestionId = 5 },
                    new Choice { Id = 18, ChoiceText = "China", QuestionId = 5 },
                    new Choice { Id = 19, ChoiceText = "South Korea", QuestionId = 5 },
                    new Choice { Id = 20, ChoiceText = "Thailand", QuestionId = 5 }

                );
        }

    }
}
