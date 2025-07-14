using Dapper;
using eshift_management.Core.Repositories;
using eshift_management.Data;
using eshift_management.Models;
using System.Text;

namespace eshift_management.Repositories
{
    /// <summary>
    /// Repository implementation for managing truck-related database operations.
    /// </summary>
    public class TruckRepository : ITruckRepository
    {
        private const string TableName = "trucks";

        // Reusable SELECT statement with column aliases to match the Truck model.
        private const string SelectSql = @"
            SELECT
                id AS Id,
                model AS Model,
                license_plate AS LicensePlate,
                status AS Status
            FROM trucks";

        public async Task<int> AddAsync(Truck entity)
        {
            const string sql = @"
                INSERT INTO trucks (model, license_plate, status)
                VALUES (@Model, @LicensePlate, @Status);
                SELECT LAST_INSERT_ID();";

            return await DbExecutor.ExecuteScalarAsync<int>(sql, new
            {
                entity.Model,
                entity.LicensePlate,
                Status = entity.Status.ToString()
            });
        }

        public async Task DeleteAsync(int id)
        {
            var sql = $"DELETE FROM {TableName} WHERE id = @Id;";
            await DbExecutor.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<IEnumerable<Truck>> GetAllAsync(Dictionary<string, object>? filter = null, string? orderBy = null, bool isAscending = true)
        {
            var sqlBuilder = new StringBuilder(SelectSql);
            var parameters = new DynamicParameters();
            var conditions = new List<string>();

            if (filter != null && filter.Any())
            {
                if (filter.TryGetValue("SearchTerm", out var searchTermValue) && searchTermValue?.ToString() is string searchTerm && !string.IsNullOrWhiteSpace(searchTerm))
                {
                    conditions.Add("(model LIKE @SearchQuery OR license_plate LIKE @SearchQuery)");
                    parameters.Add("SearchQuery", $"%{searchTerm}%");
                }
                // Add other specific filters here if needed
            }

            if (conditions.Any())
            {
                sqlBuilder.Append($" WHERE {string.Join(" AND ", conditions)}");
            }

            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                var dbColumn = orderBy.ToLowerInvariant() switch
                {
                    "model" => "model",
                    "licenseplate" => "license_plate",
                    "status" => "status",
                    _ => "id" // Default sort
                };
                sqlBuilder.Append($" ORDER BY {dbColumn} {(isAscending ? "ASC" : "DESC")}");
            }

            return await DbExecutor.QueryAsync<Truck>(sqlBuilder.ToString(), parameters);
        }

        public async Task<Truck?> GetByIdAsync(int id)
        {
            var sql = $"{SelectSql} WHERE id = @Id;";
            return await DbExecutor.QueryFirstOrDefaultAsync<Truck>(sql, new { Id = id });
        }

        public async Task UpdateAsync(Truck entity)
        {
            const string sql = @"
                UPDATE trucks SET
                    model = @Model,
                    license_plate = @LicensePlate,
                    status = @Status
                WHERE id = @Id;";

            await DbExecutor.ExecuteAsync(sql, new
            {
                entity.Id,
                entity.Model,
                entity.LicensePlate,
                Status = entity.Status.ToString()
            });
        }

        public async Task<IEnumerable<Truck>> GetByStatusAsync(ResourceStatus status)
        {
            var sql = $"{SelectSql} WHERE status = @Status;";
            return await DbExecutor.QueryAsync<Truck>(sql, new { Status = status.ToString() });
        }

        public async Task UpdateStatusAsync(int truckId, ResourceStatus status)
        {
            var sql = $"UPDATE {TableName} SET status = @Status WHERE id = @Id;";
            await DbExecutor.ExecuteAsync(sql, new { Id = truckId, Status = status.ToString() });
        }
    }
}
