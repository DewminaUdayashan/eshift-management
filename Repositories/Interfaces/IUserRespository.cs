using eshift_management.Core.Repositories;
using eshift_management.Models;
using System.Threading.Tasks;

namespace eshift_management.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<UserModel>
    {
        /// <summary>
        /// Finds a user by their email address.
        /// </summary>
        /// <param name="email">The email to search for.</param>
        /// <returns>The user model, or null if not found.</returns>
        Task<UserModel?> FindByEmailAsync(string email);

        /// <summary>
        /// Updates the password for a user.
        /// <paramref name="user">The user model containing the new password.</param>
        Task UpdatePassword(UserModel user);
    }
}
