using Microsoft.EntityFrameworkCore;
using Invoicing.Data;
using Invoicing.Services;

namespace Invoicing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add DbContext to the container
            var connectionString = builder.Configuration.GetConnectionString("InvoicingDB");
            builder.Services.AddDbContext<InvoicingDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IInvoiceService, InvoiceService>();

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
