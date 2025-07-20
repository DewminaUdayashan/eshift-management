using eshift_management.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eshift_management.Services.Interfaces
{
    /// <summary>
    /// Provides high-level user-related operations.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Gets a user by their unique ID.
        /// </summary>
        Task<UserModel?> GetByIdAsync(int id);

        /// <summary>
        /// Gets all users with optional filters and sorting.
        /// </summary>
        Task<IEnumerable<UserModel>> GetAllAsync(Dictionary<string, object>? filter = null, string? orderBy = null, bool isAscending = true);

        /// <summary>
        /// Adds a new user to the system.
        /// </summary>
        Task<int> AddAsync(UserModel user);

        /// <summary>
        /// Updates an existing user's data.
        /// </summary>
        Task UpdateAsync(UserModel user);

        /// <summary>
        /// Deletes a user by ID.
        /// </summary>
        Task DeleteAsync(int id);

        /// <summary>
        /// Finds a user by email.
        /// </summary>
        Task<UserModel?> FindByEmailAsync(string email);

        /// <summary>
        /// Updates the user's password.
        /// </summary>
        Task UpdatePassword(UserModel user);
    }
}
