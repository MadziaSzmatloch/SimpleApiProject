using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MyNewApi.Infrastructure;
using MyNewApi.Infrastructure.Seeders;

namespace MyNewApi.Test
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {
        private readonly string _connectionString = "Host=localhost;Port=5444;Database=products;Username=postgres;Password=postgres";

        public async Task InitializeAsync()
        {
            var scope = this.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<MyApiDbContext>();

            await context.Database.EnsureDeletedAsync();
            await context.Database.MigrateAsync();

            var seeder = scope.ServiceProvider.GetRequiredService<DatabaseSeeder>();
            await seeder.StartAsync(CancellationToken.None);
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.RemoveAll<DbContextOptions<MyApiDbContext>>();

                services.AddDbContext<MyApiDbContext>(options => options.UseNpgsql(_connectionString));

            });

            builder.UseEnvironment("Development");
        }

        Task IAsyncLifetime.DisposeAsync()
        {
            return Task.CompletedTask;
        }
    }

}
