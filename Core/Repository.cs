using System.Collections.Generic;
using System.Threading.Tasks;

namespace eshift_management.Core.Repositories
{
    /// <summary>
    /// A generic repository interface defining the standard data access operations.
    /// </summary>
    /// <typeparam name="T">The entity type this repository works with.</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Gets a single entity by its primary key.
        /// </summary>
        /// <param name="id">The primary key of the entity.</param>
        /// <returns>The entity, or null if not found.</returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Gets all entities, with optional filtering and sorting.
        /// </summary>
        /// <param name="filter">A dictionary of column names and values to filter by (e.g., new Dictionary<string, object> { {"Status", "Available"} }).</param>
        /// <param name="orderBy">The column name to sort by.</param>
        /// <param name="isAscending">True for ascending order, false for descending.</param>
        /// <returns>A collection of entities.</returns>
        Task<IEnumerable<T>> GetAllAsync(Dictionary<string, object> filter = null, string orderBy = null, bool isAscending = true);

        /// <summary>
        /// Adds a new entity to the database.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        Task AddAsync(T entity);

        /// <summary>
        /// Updates an existing entity in the database.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Deletes an entity from the database by its primary key.
        /// </summary>
        /// <param name="id">The primary key of the entity to delete.</param>
        Task DeleteAsync(int id);
    }
}
