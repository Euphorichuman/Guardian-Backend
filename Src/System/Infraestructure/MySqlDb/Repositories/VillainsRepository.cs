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

        public async Task<IEnumerable<Villain>> GetVillansAsync()
        {
            List<DbVillain>? dbVillians = await _context.Villains.ToListAsync();
            IEnumerable<Villain>? villians = dbVillians.Select(v => new Villain
            {
                Id = v.Id,
                Name = v.Name,
                Age = v.Age,
                Origin = v.Origin,
                Power = v.Power,
            });

            return villians;
        }
    }
}
