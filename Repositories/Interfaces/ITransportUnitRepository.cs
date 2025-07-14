using eshift_management.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eshift_management.Core.Repositories
{
    /// <summary>
    /// Repository interface for accessing and manipulating transport unit data.
    /// </summary>
    public interface ITransportUnitRepository : IRepository<TransportUnit>
    {
        /// <summary>
        /// Gets all transport units with a specific status.
        /// </summary>
        /// <param name="status">The resource status to filter by.</param>
        /// <returns>A collection of transport units.</returns>
        Task<IEnumerable<TransportUnit>> GetByStatusAsync(ResourceStatus status);

        /// <summary>
        /// Updates the status of a specific transport unit.
        /// </summary>
        /// <param name="unitId">The ID of the unit to update.</param>
        /// <param name="status">The new status to set.</param>
        Task UpdateStatusAsync(int unitId, ResourceStatus status);
    }
}
