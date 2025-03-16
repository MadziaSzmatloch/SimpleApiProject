using Microsoft.Extensions.DependencyInjection;
using MyNewApi.Application.Exceptions;
using MyNewApi.Application.Validators;
using System.Reflection;

namespace MyNewApi.Application
{
    public static class Extensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddScoped<IProductValidationPolicy, NameValidationPolicy>();
            services.AddScoped<IProductValidationPolicy, PriceValidationPolicy>();
            services.AddScoped<IProductValidationPolicy, AvailableQuantityValidationPolicy>();
            services.AddScoped<ErrorHandlingMiddleware>();
            services.AddScoped<ProductValidator>();
            services.AddScoped<ErrorHandlingMiddleware>();
        }
    }
}
