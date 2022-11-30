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

        public Task<IEnumerable<Hero>> GetHeroesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
