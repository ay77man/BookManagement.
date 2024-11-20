using BookManagement.Models;
using BookManagement.Repositery;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BookManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddScoped<IBookRepositery, BookRepositery>();
            builder.Services.AddScoped<IMemberRepositery, MemberRepositery>();
            builder.Services.AddScoped<IBorrowRecordRepositery, BorrowRecordRepositery>();

            builder.Services.AddDbContext<BookManagementDbContext>(options=>
            options.UseSqlServer(builder.Configuration.GetConnectionString("cs")));

            builder.Services.AddIdentity <ApplicationUser, ApplicationRole>(options=>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireDigit = true;
            })
                .AddEntityFrameworkStores<BookManagementDbContext>();
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
            });

                
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
