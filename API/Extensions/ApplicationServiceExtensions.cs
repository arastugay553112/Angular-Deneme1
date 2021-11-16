using API.Core.Interfaces;
using API.infrastructure.Implements;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped(typeof(IGenericRepository1<>), typeof(GenericRepository<>));
            return services;
        }
    }
}
