using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Infrastructure.Data
{
    public class QuizDbContextManager
    {
        private readonly DbContextOptions<QuizDbContext> _options;

        public QuizDbContextManager(IConfiguration configuration)
        {
            var optionsBuilder = new DbContextOptionsBuilder<QuizDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("QuizDB"));

            _options = optionsBuilder.Options;
        }

        public QuizDbContext CreateDbContext()
        {
            return new QuizDbContext(_options);
        }
    }
}
