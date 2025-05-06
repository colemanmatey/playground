using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoviesApp.Application.Interfaces;
using MoviesApp.Infrastructure.Data;
using MoviesApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MoviesDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("MoviesDB"))
            );

            services.AddScoped<IMovieRepository, MovieRepository>();

            return services;
        }
    }
}
