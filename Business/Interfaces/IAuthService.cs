using eshift_management.Models;
using System.Threading.Tasks;

namespace eshift_management.Services.Interfaces
{
    /// <summary>
    /// Defines methods for user authentication, including registration and login.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Registers a new user and associated customer record.
        /// </summary>
        /// <param name="user">The user model containing email, password hash, role, etc.</param>
        /// <param name="customer">The customer model containing customer-specific information.</param>
        /// <returns>A tuple indicating success, an optional error message, and no result object.</returns>
        Task<(bool IsSuccess, string? ErrorMessage, UserModel? user)> RegisterAsync(UserModel user, CustomerModel customer);

        /// <summary>
        /// Authenticates a user based on email and password.
        /// </summary>
        /// <param name="email">The email used for login.</param>
        /// <param name="password">The plain-text password to verify.</param>
        /// <returns>
        /// A tuple containing a success flag, an optional error message, and the authenticated UserModel if successful.
        /// </returns>
        Task<(bool IsSuccess, string? ErrorMessage, UserModel? User)> LoginAsync(string email, string password);

        /// <summary>
        /// Checks if the default administrator user exists, and creates it if not.
        /// </summary>
        Task EnsureAdminUserExistsAsync();

        /// <summary>
        /// Updates the password for a specified user.
        /// </summary>
        /// <param name="userId">The ID of the user whose password is to be updated.</param>
        /// <param name="newPassword">The new password to be set.</param>
        /// <returns>A tuple containing a boolean for success and a string for an error message if any.</returns>
        Task<(bool IsSuccess, string? ErrorMessage)> UpdatePasswordAsync(int userId, string newPassword);

        /// <summary>
        /// Requests the password reset asynchronous.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>A tuple containing boolean for success and a string for an error message if any and the UserModel</returns>
        Task<(bool IsSuccess, string? ErrorMessage, UserModel? User)> RequestPasswordResetAsync(string email);
    }
}
