using eshift_management.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eshift_management.Core.Repositories
{
    /// <summary>
    /// Repository interface for accessing and manipulating truck data.
    /// </summary>
    public interface ITruckRepository : IRepository<Truck>
    {
        /// <summary>
        /// Gets all trucks with a specific status.
        /// </summary>
        /// <param name="status">The resource status to filter by.</param>
        /// <returns>A collection of trucks matching the status.</returns>
        Task<IEnumerable<Truck>> GetByStatusAsync(ResourceStatus status);

        /// <summary>
        /// Updates the status of a specific truck.
        /// </summary>
        /// <param name="truckId">The ID of the truck to update.</param>
        /// <param name="status">The new status to set.</param>
        Task UpdateStatusAsync(int truckId, ResourceStatus status);
    }
}
