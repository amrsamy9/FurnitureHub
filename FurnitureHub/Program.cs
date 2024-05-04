using FurnitureHub.Models;
using FurnitureHub.Repository;
using Microsoft.EntityFrameworkCore;

namespace FurnitureHub
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            #region  add connectionstring
            builder.Services.AddDbContext<StoreContext>
                 (Options => Options.UseSqlServer("Server=ADMINISTRATOR\\SQLEXPRESS; Database=FurnitureHub; Trusted_Connection=True; Encrypt=false;"));
            #endregion
            builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();


            // Add services to the container.
            builder.Services.AddControllersWithViews();

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
