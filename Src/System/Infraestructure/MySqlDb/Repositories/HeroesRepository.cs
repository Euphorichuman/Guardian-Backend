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

        public async Task<IEnumerable<Hero>> GetHeroesAsync()
        {
            List<DbHero>? dbHeroes = await _context.Heroes.ToListAsync();
            IEnumerable<Hero>? heroes = dbHeroes.Select(v => new Hero
            {
                Id = v.Id,
                Name = v.Name,
                Age = v.Age,
            });

            return heroes;
        }
    }
}
