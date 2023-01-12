using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using StoreOfBuild.Data;
using Microsoft.Extensions.Configuration;
using System;
using StoreOfBuild.Domain;
using StoreOfBuild.Domain.Products;

namespace StoreOfBuild.DI;

public class BootStrap
{
    public static void Configure(IServiceCollection services, string connectionStr)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(connectionStr));

        services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));
        services.AddSingleton(typeof(CategoryStore));
    }
}