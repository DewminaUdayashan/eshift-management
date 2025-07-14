using eshift_management.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eshift_management.Core.Services
{
    /// <summary>
    /// Defines the contract for truck-related business operations.
    /// </summary>
    public interface ITruckService
    {
        /// <summary>
        /// Retrieves all trucks, with optional filtering and sorting.
        /// </summary>
        /// <param name="filter">A dictionary for filtering. Supports a 'SearchTerm' key.</param>
        /// <param name="orderBy">The property to sort by.</param>
        /// <param name="isAscending">The sort direction.</param>
        /// <returns>A collection of trucks.</returns>
        Task<IEnumerable<Truck>> GetAllTrucksAsync(Dictionary<string, object>? filter = null, string? orderBy = null, bool isAscending = true);

        /// <summary>
        /// Retrieves a single truck by its ID.
        /// </summary>
        /// <param name="id">The ID of the truck.</param>
        Task<Truck?> GetTruckByIdAsync(int id);

        /// <summary>
        /// Retrieves all trucks with a specific status.
        /// </summary>
        /// <param name="status">The status to filter by.</param>
        Task<IEnumerable<Truck>> GetTrucksByStatusAsync(ResourceStatus status);

        /// <summary>
        /// Creates a new truck record.
        /// </summary>
        /// <param name="truck">The truck data to insert.</param>
        /// <returns>The newly created truck ID.</returns>
        Task<int> CreateTruckAsync(Truck truck);

        /// <summary>
        /// Updates an existing truck record.
        /// </summary>
        /// <param name="truck">The truck data with updates.</param>
        Task UpdateTruckAsync(Truck truck);

        /// <summary>
        /// Deletes a truck by its ID.
        /// </summary>
        /// <param name="id">The ID of the truck to delete.</param>
        Task DeleteTruckAsync(int id);

        /// <summary>
        /// Updates the status of a specific truck.
        /// </summary>
        /// <param name="truckId">The ID of the truck.</param>
        /// <param name="status">The new status.</param>
        Task UpdateTruckStatusAsync(int truckId, ResourceStatus status);
    }
}
