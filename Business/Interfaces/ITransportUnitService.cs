using eshift_management.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eshift_management.Core.Services
{
    /// <summary>
    /// Defines the contract for transport unit-related business operations.
    /// </summary>
    public interface ITransportUnitService
    {
        /// <summary>
        /// Retrieves all transport units with their associated details.
        /// </summary>
        /// <param name="filter">A dictionary for filtering. Supports a 'SearchTerm' key.</param>
        /// <param name="orderBy">The property to sort by.</param>
        /// <param name="isAscending">The sort direction.</param>
        /// <returns>A collection of transport units.</returns>
        Task<IEnumerable<TransportUnit>> GetAllTransportUnitsAsync(Dictionary<string, object>? filter = null, string? orderBy = null, bool isAscending = true);

        /// <summary>
        /// Retrieves a single, fully populated transport unit by its ID.
        /// </summary>
        /// <param name="id">The ID of the transport unit.</param>
        Task<TransportUnit?> GetTransportUnitByIdAsync(int id);

        /// <summary>
        /// Retrieves all transport units with a specific status.
        /// </summary>
        /// <param name="status">The status to filter by.</param>
        Task<IEnumerable<TransportUnit>> GetTransportUnitsByStatusAsync(ResourceStatus status);

        /// <summary>
        /// Creates a new transport unit.
        /// </summary>
        /// <param name="unit">The transport unit data to insert.</param>
        /// <returns>The newly created unit ID.</returns>
        Task<int> CreateTransportUnitAsync(TransportUnit unit);

        /// <summary>
        /// Updates an existing transport unit.
        /// </summary>
        /// <param name="unit">The transport unit data with updates.</param>
        Task UpdateTransportUnitAsync(TransportUnit unit);

        /// <summary>
        /// Deletes a transport unit by its ID.
        /// </summary>
        /// <param name="id">The ID of the unit to delete.</param>
        Task DeleteTransportUnitAsync(int id);

        /// <summary>
        /// Updates the status of a specific transport unit.
        /// </summary>
        /// <param name="unitId">The ID of the unit.</param>
        /// <param name="status">The new status.</param>
        Task UpdateTransportUnitStatusAsync(int unitId, ResourceStatus status);
    }
}
