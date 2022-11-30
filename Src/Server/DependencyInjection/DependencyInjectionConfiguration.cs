namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddGuardianModules(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            services.AddGuardianSystem(configuration);

            return services;
        }
    }
}
