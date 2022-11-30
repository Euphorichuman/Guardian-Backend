using Guardian.System.Core.Domain.Entities;
using Guardian.System.Core.Domain.Repositories;
using Guardian.System.Infraestructure.MySqlDb.Context;
using Guardian.System.Infraestructure.MySqlDb.Entities;

namespace Guardian.System.Infraestructure.MySqlDb.Repositories
{
    public class HeroesRepository : IHeroesRepository
    {
        private readonly SystemDbContext _context;

        public HeroesRepository(SystemDbContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<IEnumerable<Hero>> GetHeroesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
