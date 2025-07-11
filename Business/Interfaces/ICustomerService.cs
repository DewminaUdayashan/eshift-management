using eshift_management.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eshift_management.Services.Interfaces
{
    /// <summary>
    /// Provides an abstraction for business logic related to customers.
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// Retrieves a single customer by their unique user ID.
        /// </summary>
        /// <param name="id">The user ID of the customer.</param>
        /// <returns>The matching <see cref="CustomerModel"/> or null if not found.</returns>
        Task<CustomerModel?> GetByIdAsync(int id);

        /// <summary>
        /// Retrieves all customers, optionally filtered and sorted.
        /// </summary>
        /// <param name="filter">A dictionary of column-value pairs to filter by.</param>
        /// <param name="orderBy">The column name to order results by.</param>
        /// <param name="isAscending">True for ascending sort, false for descending.</param>
        /// <returns>A list of <see cref="CustomerModel"/> objects.</returns>
        Task<IEnumerable<CustomerModel>> GetAllAsync(Dictionary<string, object>? filter = null, string? orderBy = null, bool isAscending = true);

        /// <summary>
        /// Adds a new customer to the database.
        /// </summary>
        /// <param name="customer">The customer data to insert.</param>
        /// <returns>The generated user ID of the newly added customer.</returns>
        Task<int> AddAsync(CustomerModel customer);

        /// <summary>
        /// Updates an existing customer in the database.
        /// </summary>
        /// <param name="customer">The customer data with updated values.</param>
        Task UpdateAsync(CustomerModel customer);

        /// <summary>
        /// Deletes a customer by their user ID.
        /// </summary>
        /// <param name="id">The user ID of the customer to delete.</param>
        Task DeleteAsync(int id);
    }
}
