using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyTechBusiness.Abstract;
using MyTechBusiness.Concrete;
using MyTechData.Abstract;
using MyTechData.Concrete.Ef;
using MyTechWebUı.EmailSevices;
using MyTechWebUı.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration.Provider;
using System.Configuration;

namespace MyTechWebUı
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var serviceProvider = builder.Services.BuildServiceProvider();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();

            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer("server=ADMINISTRATOR;database=MyTechDb;integrated security=true;"));
            builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();
            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;

                //Lockout
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.AllowedForNewUsers = true;

                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });

    

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/account/login";
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".MyTech.Securitiy.Cookie",
                    SameSite = SameSiteMode.Strict

                };
            });

            builder.Services.AddScoped<IProductRepository, EfProductRepository>();
            builder.Services.AddScoped<ICategoryRepository, EfCategoryRepository>();
            builder.Services.AddScoped<IReviewRepository, EfReviewRepository>();
            builder.Services.AddScoped<ICartRepository, EfCartRepository>();
            builder.Services.AddScoped<IOrderRepository, EfOrderRepository>();

            builder.Services.AddScoped<IProductService, ProductManager>();
            builder.Services.AddScoped<ICategoryService, CategoryManager>();
            builder.Services.AddScoped<IReviewService, ReviewManager>();
            builder.Services.AddScoped<ICartService, CartManager>();
            builder.Services.AddScoped<IOrderService, OrderManager>();

         
            builder.Services.AddScoped<IEmailSender, GmailSender>(i =>
            new GmailSender(
                  builder.Configuration["EmailSender:Host"],
                  builder.Configuration.GetValue<int>("EmailSender:Port"),
                  builder.Configuration.GetValue<bool>("EmailSender:EnableSSL"),
                  builder.Configuration["EmailSender:UserName"],
                  builder.Configuration["EmailSender:Password"]
                ));

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
            app.UseAuthentication();


            app.UseRouting();
            app.UseAuthorization();

            var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                SeedIdentity.Seed(userManager, roleManager, configuration).Wait();
            }

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}