using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using StoreOfBuild.Data;
using System;

namespace StoreOfBuild.DI;

public class BootStrap
{
    public static void Configure(IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite());
    }
}