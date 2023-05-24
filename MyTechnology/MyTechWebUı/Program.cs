using Microsoft.EntityFrameworkCore;
using MyTechBusiness.Abstract;
using MyTechBusiness.Concrete;
using MyTechData.Abstract;
using MyTechData.Concrete.Ef;
using System;

namespace MyTechWebUı
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IProductRepository, EfProductRepository>();
            builder.Services.AddScoped<ICategoryRepository, EfCategoryRepository>();
            builder.Services.AddScoped<IReviewRepository, EfReviewRepository>();

            builder.Services.AddScoped<IProductService, ProductManager>();
            builder.Services.AddScoped<ICategoryService, CategoryManager>();
            builder.Services.AddScoped<IReviewService, ReviewManager>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();



            var app = builder.Build();

            if (builder.Environment.IsDevelopment())
            {
                SeedDatabase.Seed();
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Admin}/{action=Index}/{id?}");

            app.Run();
        }
    }
}