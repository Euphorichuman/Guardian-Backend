using Guardian.System.Core.Domain.Entities;

namespace Guardian.System.Core.Domain.Repositories
{
    public interface IVilliansRepository
    {
        /// <summary>
        /// Get all the persisted villians of the system.
        /// </summary>
        /// <returns>A collection of <see cref="Villian"/>.</returns>
        public Task<IEnumerable<Villian>> GetVillansAsync();
    }
}
