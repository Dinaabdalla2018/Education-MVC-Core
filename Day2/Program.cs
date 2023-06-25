using Day2.Models;
using Day2.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace Day2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //service type
            //1- framwork service
            //a- service found frmwork alread register in ioc container
            //b- service found framwrk but not register
            // Add services to the container. Day8 injection
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession();

            //Register Option,DB_Content
            builder.Services.AddDbContext<DB_Context>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("SC"))
            );
            ///////////////////////////
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            //////////////////////////////
            //2- custom servvice :custome class need to register
            //                        <inject(class,intercae),resolve class>
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}