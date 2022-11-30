using Guardian.System.Core.Domain.Entities;

namespace Guardian.System.Core.Domain.Repositories
{
    public interface IHeroesRepository
    {
        /// <summary>
        /// Get all the persisted heroes of the system.
        /// </summary>
        /// <returns>A collection of <see cref="Hero"/>.</returns>
        public Task<IEnumerable<Hero>> GetHeroesAsync();
    }
}
