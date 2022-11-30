using Guardian.System.Core.Domain.Entities;

namespace Guardian.System.Core.Domain.Services
{
    public interface IVilliansService
    {
        /// <summary>
        /// Will process and get all villians of the system.
        /// </summary>
        /// <returns>A collection of <see cref="Villian"/>.</returns>
        public Task<IEnumerable<Villian>> GetVillansAsync();
    }
}
