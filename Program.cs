using Day_3_2.Models;
using Day_3_2.Repos;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace Day_3_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(); // (a =>
                //{
                //    a.LoginPath = "index";
                //});
            builder.Services.AddScoped<IDeptRepo, DepartmentRepo>();
            builder.Services.AddScoped<IStudentRepo, StudentRepo>();
            builder.Services.AddDbContext<ApplicationContext>(a => {
                a.UseSqlServer("data source = . ; initial catalog = MVC1 ; integrated security = true ; Trust Server Certificate = true");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


          //  app.Use(async (context, next) =>
          //  {
          //      await context.Response.WriteAsync("hello from 1 middleware");
          //      await next.Invoke();
          //      await context.Response.WriteAsync("hello from 2 middleware");

          //  }
          //);
          //  app.Run(async (context) =>
          //  {
          //      await context.Response.WriteAsync("hello from 1 middleware");
          //  }
          //  );
            app.Run();

        }
    }
}
