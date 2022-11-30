using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGuardianSystem(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSystemCoreApplication();

            return services;
        }
    }
}
