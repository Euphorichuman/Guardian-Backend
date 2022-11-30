using Guardian.System.Core.Domain.Entities;
using Guardian.System.Core.Domain.Repositories;
using Guardian.System.Core.Domain.Services;

namespace Guardian.System.Core.Application.Services
{
    public class VillainsService : IVillainsService
    {
        private readonly IVillainsRepository _villiansRepository;

        public VillainsService(IVillainsRepository villiansRepository)
        {
            _villiansRepository = villiansRepository ?? throw new ArgumentNullException(nameof(villiansRepository));
        }

        public async Task<IEnumerable<Villain>> GetVillansAsync()
        {
            return await this._villiansRepository.GetVillansAsync();
        }
    }
}
