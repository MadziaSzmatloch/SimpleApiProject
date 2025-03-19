using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyNewApi.Domain.Interfaces;
using MyNewApi.Infrastructure.Repositories;
using MyNewApi.Infrastructure.Seeders;

namespace MyNewApi.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyApiDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("Database")));
            services.AddHostedService<DatabaseMigrationService>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBannedWordRepository, BannedWordRepository>();
            services.AddScoped<IProductHistoryRepository, ProductHistoryRepository>();
            services.AddScoped<CategorySeeder>();
            services.AddScoped<BannedWordsSeeder>();
            services.AddHostedService<DatabaseSeeder>();
            services.AddTransient<DatabaseSeeder>();  //For tests

            return services;
        }
    }
}
