using Guardian.System.Core.Domain.Entities;
using Guardian.System.Core.Domain.Services;
using Guardian.System.Core.Domain.Entities;

namespace Guardian.System.Core.Application.Services
{
    public class VilliansService : IVilliansService
    {
        private readonly IVilliansService _villiansService;

        public VilliansService(IVilliansService villiansService)
        {
            _villiansService = villiansService ?? throw new ArgumentNullException(nameof(villiansService)); ;
        }

        public Task<IEnumerable<Villian>> GetVillansAsync()
        {
            throw new NotImplementedException();
        }
    }
}
