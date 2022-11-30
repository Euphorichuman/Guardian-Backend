using Guardian.System.Core.Domain.Entities;
using Guardian.System.Core.Domain.Repositories;
using Guardian.System.Infraestructure.MySqlDb.Context;
using Guardian.System.Infraestructure.MySqlDb.Entities;

namespace Guardian.System.Infraestructure.MySqlDb.Repositories
{
    public class VilliansRepository : IVilliansRepository
    {
        private readonly SystemDbContext _context;

        public VilliansRepository(SystemDbContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<IEnumerable<Villian>> GetVillansAsync()
        {
            throw new NotImplementedException();
        }
    }
}
