using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MyNewApi.Infrastructure.Seeders
{
    public class DatabaseSeeder(IServiceProvider serviceProvider) : IHostedService
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var bannedWordsSeeder = scope.ServiceProvider.GetRequiredService<BannedWordsSeeder>();
            var categorySeeder = scope.ServiceProvider.GetRequiredService<CategorySeeder>();
            await categorySeeder.Seed();
            await bannedWordsSeeder.Seed();
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
