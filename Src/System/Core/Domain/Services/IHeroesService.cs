using Guardian.System.Core.Domain.Entities;

namespace Guardian.System.Core.Domain.Services
{
    public interface IHeroesService
    {
        /// <summary>
        /// Will process and get all heroes of the system.
        /// </summary>
        /// <returns>A collection of <see cref="Hero"/>.</returns>
        public Task<IEnumerable<Hero>> GetHeroesAsync();
    }
}
