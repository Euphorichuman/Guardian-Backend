using Guardian.System.Core.Domain.Entities;
using Guardian.System.Core.Domain.Services;
using Guardian.System.Core.Domain.Entities;

namespace Guardian.System.Core.Application.Services
{
    public class HeroesService : IVilliansService
    {
        private readonly IVilliansService _heroesService;

        public HeroesService(IVilliansService heroesService)
        {
            _heroesService = heroesService ?? throw new ArgumentNullException(nameof(heroesService)); ;
        }

        public Task<IEnumerable<Villian>> GetVillansAsync()
        {
            throw new NotImplementedException();
        }
    }
}
