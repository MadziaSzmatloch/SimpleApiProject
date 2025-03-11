using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyNewApi.Domain.Interfaces;
using MyNewApi.Infrastructure.Repositories;

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

            return services;
        }
    }
}
