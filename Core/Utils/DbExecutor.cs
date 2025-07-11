using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eshift_management.Data
{
    /// <summary>
    /// A static utility class to handle database query and command executions using Dapper.
    /// This class centralizes database interaction logic.
    /// </summary>
    public static class DbExecutor
    {
        // Retrieves the connection string once and reuses it.
        private static readonly string _connectionString = DbConnectionHelper.GetConnectionString();

        /// <summary>
        /// Executes a query that returns a collection of results.
        /// </summary>
        public static async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? parameters = null)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                return await connection.QueryAsync<T>(sql, parameters);
            }
        }

        /// <summary>
        /// Executes a query that returns a single record or a default value (null for reference types).
        /// </summary>
        public static async Task<T?> QueryFirstOrDefaultAsync<T>(string sql, object? parameters = null)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<T>(sql, parameters);
            }
        }

        /// <summary>
        /// Executes a command (e.g., INSERT, UPDATE, DELETE) and returns the number of rows affected.
        /// </summary>
        public static async Task<int> ExecuteAsync(string sql, object? parameters = null)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                return await connection.ExecuteAsync(sql, parameters);
            }
        }

        /// <summary>
        /// Executes a scalar query and returns a single value of the specified type.
        /// Commonly used for retrieving auto-incremented IDs or aggregates (e.g., COUNT, SUM).
        /// </summary>
        /// <typeparam name="T">The expected return type.</typeparam>
        /// <param name="sql">The SQL query to execute.</param>
        /// <param name="parameters">Optional query parameters.</param>
        /// <returns>The single value result of the query.</returns>
        public static async Task<T?> ExecuteScalarAsync<T>(string sql, object? parameters = null)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                return await connection.ExecuteScalarAsync<T>(sql, parameters);
            }
        }
    }
}
