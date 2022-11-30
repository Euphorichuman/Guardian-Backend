using Guardian.System.Core.Domain.Entities;

namespace Guardian.System.Core.Domain.Repositories
{
    public interface IVillainsRepository
    {
        /// <summary>
        /// Get all the persisted villians of the system.
        /// </summary>
        /// <returns>A collection of <see cref="Villain"/>.</returns>
        public Task<IEnumerable<Villain>> GetVillainsAsync();
    }
}
