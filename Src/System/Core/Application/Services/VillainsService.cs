using Guardian.System.Core.Domain.Entities;
using Guardian.System.Core.Domain.Repositories;
using Guardian.System.Core.Domain.Services;

namespace Guardian.System.Core.Application.Services
{
    public class VillainsService : IVillainsService
    {
        private readonly IVillainsRepository _villainsRepository;

        public VillainsService(IVillainsRepository villainsRepository)
        {
            _villainsRepository = villainsRepository ?? throw new ArgumentNullException(nameof(villainsRepository));
        }

        public async Task<IEnumerable<Villain>> GetVillainsAsync()
        {
            return await this._villainsRepository.GetVillainsAsync();
        }
    }
}
