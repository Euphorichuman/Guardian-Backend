using Guardian.System.Core.Application.Services;
using Guardian.System.Core.Domain.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static partial class ServiceCollectionExtensions
    {
        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IHeroesService, HeroesService>();
            services.AddScoped<IVillainsService, VillainsService>();

            return services;
        }
    }
}
