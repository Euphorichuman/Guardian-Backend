namespace Microsoft.Extensions.DependencyInjection
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSystemCoreApplication(this IServiceCollection services)
        {
            services.AddServices();

            return services;
        }
    }
}
