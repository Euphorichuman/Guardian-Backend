using Guardian.System.Core.Domain.Entities;
using Guardian.System.Core.Domain.Repositories;
using Guardian.System.Infraestructure.MySqlDb.Context;
using Guardian.System.Infraestructure.MySqlDb.Entities;

namespace Guardian.System.Infraestructure.MySqlDb.Repositories
{
    public class VillainsRepository : IVillainsRepository
    {
        private readonly SystemDbContext _context;

        public VillainsRepository(SystemDbContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Villain>> GetVillainsAsync()
        {
            List<DbVillain>? dbVillains = await _context.Villains.ToListAsync();
            IEnumerable<Villain>? villains = dbVillains.Select(v => new Villain
            {
                Id = v.Id,
                Name = v.Name,
                Age = v.Age,
                Origin = v.Origin,
                Power = v.Power,
            });

            return villains;
        }
    }
}
