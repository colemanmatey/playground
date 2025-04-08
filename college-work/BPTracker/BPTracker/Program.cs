using BPTracker.Data;
using BPTracker.Services;
using Microsoft.EntityFrameworkCore;

namespace BPTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register the database context
            builder.Services.AddDbContext<BPTrackerDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IBPMeasurementService, BPMeasurementService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
