using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MyNewApi.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyApiDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("Database")));
            services.AddHostedService<DatabaseMigrationService>();

            return services;
        }
    }
}
