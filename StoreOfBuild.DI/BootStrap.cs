using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using StoreOfBuild.Data;
using Microsoft.Extensions.Configuration;
using System;
using StoreOfBuild.Domain;
using StoreOfBuild.Domain.Products;
using StoreOfBuild.Data.Repositories;
using StoreOfBuild.Domain.Sale;
using StoreOfBuild.Data.Identity;
using Microsoft.AspNetCore.Identity;
using StoreOfBuild.Domain.Account;
using System.Net;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace StoreOfBuild.DI;

public class BootStrap
{
    public static void Configure(IServiceCollection services, string connectionStr)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(connectionStr));

        services.AddIdentity<ApplicationUser, IdentityRole>(config =>
        {
            config.Password.RequireDigit = false;
            config.Password.RequiredLength = 6;
            config.Password.RequireNonAlphanumeric = false;
            config.Password.RequireLowercase = false;
            config.Password.RequireUppercase = false;
            config.User.RequireUniqueEmail = true;
        })
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie();
        //services.ConfigureApplicationCookie(options => options.AccessDeniedPath = "/Account/Login");
        //services.ConfigureApplicationCookie(config => config.LoginPath = "/Account/Login");

        services.AddTransient(typeof(IRepository<Product>), typeof(ProductRepository));
        services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        services.AddTransient(typeof(IManager), typeof(Manager));
        services.AddTransient(typeof(CategoryStore));
        services.AddTransient(typeof(ProductStore));
        services.AddTransient(typeof(SaleFactory));
        services.AddTransient(typeof(IAuthentication), typeof(Authentication));
        services.AddScoped(typeof(IUnityOfWork), typeof(UnityOfWork));

    }
}