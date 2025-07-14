using Dapper;
using MySql.Data.MySqlClient;

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
        /// Executes a multi-mapping query that joins multiple tables and returns a collection of results.
        /// </summary>
        /// <typeparam name="TFirst">The first type in the result set.</typeparam>
        /// <typeparam name="TSecond">The second type in the result set.</typeparam>
        /// <typeparam name="TThird">The third type in the result set.</typeparam>
        /// <typeparam name="TReturn">The return type of the mapping function.</typeparam>
        /// <param name="sql">The SQL query to execute.</param>
        /// <param name="map">The function to map row types to a single return type.</param>
        /// <param name="parameters">Optional query parameters.</param>
        /// <param name="splitOn">A comma-separated string that tells Dapper when the next object begins.</param>
        /// <returns>A collection of mapped objects.</returns>
        public static async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(
            string sql,
            Func<TFirst, TSecond, TThird, TReturn> map,
            object? parameters = null,
            string splitOn = "Id")
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                return await connection.QueryAsync(sql, map, parameters, splitOn: splitOn);
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
