using Guardian.System.Core.Domain.Entities;
using Guardian.System.Core.Domain.Repositories;
using Guardian.System.Core.Domain.Services;

namespace Guardian.System.Core.Application.Services
{
    public class HeroesService : IHeroesService
    {
        private readonly IHeroesRepository _heroesRepository;

        public HeroesService(IHeroesRepository heroesRepository)
        {
            _heroesRepository = heroesRepository ?? throw new ArgumentNullException(nameof(heroesRepository));
        }

        public async Task<IEnumerable<Hero>> GetHeroesAsync()
        {
            return await this._heroesRepository.GetHeroesAsync();
        }
    }
}
