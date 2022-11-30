using Guardian.System.Core.Domain.Entities;

namespace Guardian.System.Core.Domain.Services
{
    public interface IVillainsService
    {
        /// <summary>
        /// Will process and get all villians of the system.
        /// </summary>
        /// <returns>A collection of <see cref="Villain"/>.</returns>
        public Task<IEnumerable<Villain>> GetVillansAsync();
    }
}
