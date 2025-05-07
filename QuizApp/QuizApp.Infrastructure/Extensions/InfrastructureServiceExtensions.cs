using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuizApp.Application.Interfaces;
using QuizApp.Infrastructure.Data;
using QuizApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Infrastructure.Extensions
{
    public static class InfrastructureServiceExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<QuizDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("QuizDB"))
            );
            services.AddScoped<IQuizRepository, QuizRepository>();
            return services;
        }
    }
}
