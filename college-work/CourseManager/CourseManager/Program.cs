using CourseManager.Data;
using CourseManager.Services;
using Microsoft.EntityFrameworkCore;

namespace CourseManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Get the connection string from appsettings.json
            var connectionString = builder.Configuration.GetConnectionString("CourseManagerDB");

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<CourseManagerDbContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddScoped<IEmailService, EmailService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
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
