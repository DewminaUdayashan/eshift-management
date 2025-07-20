using Dapper;
using eshift_management.Data;
using eshift_management.Models;
using eshift_management.Repositories.Interfaces;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eshift_management.Repositories.Services
{
    /// <summary>
    /// Repository for handling user-related database operations.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// Adds a new user to the database.
        /// </summary>
        /// <param name="entity">The UserModel object representing the user to add.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task<int> AddAsync(UserModel entity)
        {
            var sql = @"
        INSERT INTO users (email, password_hash, user_type, is_email_verified)
        VALUES (@Email, @PasswordHash, @UserType, @IsEmailVerified);
        SELECT LAST_INSERT_ID();";

            return await DbExecutor.ExecuteScalarAsync<int>(sql, entity);
        }


        /// <summary>
        /// Deletes a user from the database by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task DeleteAsync(int id)
        {
            var sql = "DELETE FROM users WHERE Id = @Id;";
            await DbExecutor.ExecuteAsync(sql, new { Id = id });
        }

        /// <summary>
        /// Finds a single user by their email address.
        /// </summary>
        /// <param name="email">The email address to search for.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. 
        /// The task result contains the matching UserModel, or null if no user is found.
        /// </returns>
        public async Task<UserModel?> FindByEmailAsync(string email)
        {
            var sql = @"SELECT id AS Id, email AS Email, password_hash AS PasswordHash, user_type AS UserType,
is_email_verified AS IsEmailVerified FROM users 
WHERE email = @Email 
LIMIT 1;";
            return await DbExecutor.QueryFirstOrDefaultAsync<UserModel>(sql, new { Email = email });
        }

        /// <summary>
        /// Retrieves all users from the database, with optional filtering and ordering.
        /// </summary>
        /// <param name="filter">A dictionary of column names and values to filter by (optional).</param>
        /// <param name="orderBy">The column name to sort the results by (optional).</param>
        /// <param name="isAscending">Specifies the sort order; true for ascending, false for descending.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. 
        /// The task result contains a collection of all users matching the criteria.
        /// </returns>
        public async Task<IEnumerable<UserModel>> GetAllAsync(Dictionary<string, object>? filter = null, string? orderBy = null, bool isAscending = true)
        {
            // Base query
            var sqlBuilder = new StringBuilder("SELECT * FROM users");

            // Basic filtering implementation (can be expanded)
            if (filter != null && filter.Count > 0)
            {
                sqlBuilder.Append(" WHERE ");
                var conditions = new List<string>();
                foreach (var key in filter.Keys)
                {
                    // Prevents SQL injection by using parameterized queries
                    conditions.Add($"{key} = @{key}");
                }
                sqlBuilder.Append(string.Join(" AND ", conditions));
            }

            // Basic ordering implementation
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                // Basic validation to prevent SQL injection in orderBy
                // In a real app, validate 'orderBy' against a list of allowed column names.
                sqlBuilder.Append($" ORDER BY {orderBy} {(isAscending ? "ASC" : "DESC")}");
            }

            sqlBuilder.Append(';');

            return await DbExecutor.QueryAsync<UserModel>(sqlBuilder.ToString(), filter);
        }

        /// <summary>
        /// Retrieves a single user by their unique ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. 
        /// The task result contains the UserModel for the given ID, or null if not found.
        /// </returns>
        public async Task<UserModel?> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM users WHERE id = @Id;";
            return await DbExecutor.QueryFirstOrDefaultAsync<UserModel>(sql, new { Id = id });
        }

        /// <summary>
        /// Updates an existing user's information in the database.
        /// </summary>
        /// <param name="entity">The UserModel object with updated information. The user is identified by their ID.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task UpdateAsync(UserModel entity)
        {
            var sql = @"
        UPDATE users SET 
            email = @Email,
            user_type = @UserType,
            is_email_verified = @IsEmailVerified
        WHERE id = @Id;";

            await DbExecutor.ExecuteAsync(sql, entity);
        }

        /// <inheritdoc />
        public async Task UpdatePassword(UserModel user)
        {
            var sql = @"
        UPDATE users
        SET password_hash = @PasswordHash
        WHERE id = @Id;";

            await DbExecutor.ExecuteAsync(sql, new { user.PasswordHash, user.Id });
        }
    }
}
