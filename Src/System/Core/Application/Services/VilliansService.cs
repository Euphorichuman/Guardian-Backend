using Guardian.System.Core.Domain.Entities;
using Guardian.System.Core.Domain.Repositories;
using Guardian.System.Core.Domain.Services;

namespace Guardian.System.Core.Application.Services
{
    public class VilliansService : IVilliansService
    {
        private readonly IVilliansRepository _villiansRepository;

        public VilliansService(IVilliansRepository villiansRepository)
        {
            _villiansRepository = villiansRepository ?? throw new ArgumentNullException(nameof(villiansRepository));
        }

        public Task<IEnumerable<Villian>> GetVillansAsync()
        {
            throw new NotImplementedException();
        }
    }
}
