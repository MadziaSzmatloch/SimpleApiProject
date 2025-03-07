using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MyNewApi.Application
{
    public static class Extensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
