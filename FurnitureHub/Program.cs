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
            builder.Services.AddDbContext<StoreContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("AP")));
            #endregion
           builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();


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
            app.MapControllerRoute(
                name: "default",
                 pattern: "{area:Admin}/{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
