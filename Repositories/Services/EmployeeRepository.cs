using Dapper;
using eshift_management.Core.Repositories;
using eshift_management.Data;
using eshift_management.Models;
using System.Text;

namespace eshift_management.Repositories
{
    /// <summary>
    /// Repository implementation for managing employee-related database operations.
    /// Uses explicit SQL aliases to map snake_case columns to PascalCase model properties.
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        private const string TableName = "employees";

        // Reusable SELECT statement with all column aliases defined.
        private const string SelectSql = @"
            SELECT
                id AS Id,
                first_name AS FirstName,
                last_name AS LastName,
                contact_number AS ContactNumber,
                position AS Position,
                license_number AS LicenseNumber,
                status AS Status
            FROM employees";

        public async Task<int> AddAsync(Employee entity)
        {
            const string sql = @"
                INSERT INTO employees (first_name, last_name, contact_number, position, license_number, status)
                VALUES (@FirstName, @LastName, @ContactNumber, @Position, @LicenseNumber, @Status);
                SELECT LAST_INSERT_ID();";

            // Pass enum values as strings to match the database ENUM type.
            return await DbExecutor.ExecuteScalarAsync<int>(sql, new
            {
                entity.FirstName,
                entity.LastName,
                entity.ContactNumber,
                Position = entity.Position.ToString(),
                entity.LicenseNumber, // Dapper handles null correctly
                Status = entity.Status.ToString()
            });
        }

        public async Task DeleteAsync(int id)
        {
            var sql = $"DELETE FROM {TableName} WHERE id = @Id;";
            await DbExecutor.ExecuteAsync(sql, new { Id = id });
        }

        public Task<IEnumerable<Employee>> GetAllAsync(Dictionary<string, object>? filter = null, string? orderBy = null, bool isAscending = true)
        {
            var sqlBuilder = new StringBuilder(SelectSql);
            var parameters = new DynamicParameters();
            var conditions = new List<string>();

            if (filter != null && filter.Any())
            {
                // Check for the special 'SearchTerm' key for broad, multi-column searching.
                if (filter.TryGetValue("SearchTerm", out var searchTermValue) && searchTermValue?.ToString() is string searchTerm && !string.IsNullOrWhiteSpace(searchTerm))
                {
                    conditions.Add(@"(
                        id LIKE @SearchQuery OR
                        CONCAT(first_name, ' ', last_name) LIKE @SearchQuery OR
                        contact_number LIKE @SearchQuery
                    )");
                    parameters.Add("SearchQuery", $"%{searchTerm}%");
                }

                // Here you could add more specific filters, e.g.,
                // if (filter.TryGetValue("Position", out var positionValue)) { ... }
            }

            if (conditions.Any())
            {
                sqlBuilder.Append($" WHERE {string.Join(" AND ", conditions)}");
            }

            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                var dbColumn = orderBy.ToLowerInvariant() switch
                {
                    "name" => "CONCAT(first_name, ' ', last_name)",
                    "position" => "position",
                    "id" => "id",
                    _ => "id" // Default sort column
                };
                sqlBuilder.Append($" ORDER BY {dbColumn} {(isAscending ? "ASC" : "DESC")}");
            }

            return DbExecutor.QueryAsync<Employee>(sqlBuilder.ToString(), parameters);
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            var sql = $"{SelectSql} WHERE id = @Id;";
            return await DbExecutor.QueryFirstOrDefaultAsync<Employee>(sql, new { Id = id });
        }

        public async Task UpdateAsync(Employee entity)
        {
            const string sql = @"
                UPDATE employees SET
                    first_name = @FirstName,
                    last_name = @LastName,
                    contact_number = @ContactNumber,
                    position = @Position,
                    license_number = @LicenseNumber,
                    status = @Status
                WHERE id = @Id;";

            await DbExecutor.ExecuteAsync(sql, new
            {
                entity.Id,
                entity.FirstName,
                entity.LastName,
                entity.ContactNumber,
                Position = entity.Position.ToString(),
                entity.LicenseNumber,
                Status = entity.Status.ToString()
            });
        }

        public async Task<IEnumerable<Employee>> GetByPositionAsync(EmployeePosition position)
        {
            var sql = $"{SelectSql} WHERE position = @Position;";
            return await DbExecutor.QueryAsync<Employee>(sql, new { Position = position.ToString() });
        }

        public async Task<IEnumerable<Employee>> GetByStatusAsync(ResourceStatus status)
        {
            var sql = $"{SelectSql} WHERE status = @Status;";
            return await DbExecutor.QueryAsync<Employee>(sql, new { Status = status.ToString() });
        }

        public async Task UpdateStatusAsync(int employeeId, ResourceStatus status)
        {
            var sql = $"UPDATE {TableName} SET status = @Status WHERE id = @Id;";
            await DbExecutor.ExecuteAsync(sql, new { Id = employeeId, Status = status.ToString() });
        }
    }
}
