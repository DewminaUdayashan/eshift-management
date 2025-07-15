using Dapper;
using eshift_management.Core.Repositories;
using eshift_management.Data;
using eshift_management.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshift_management.Repositories
{
    /// <summary>
    /// Repository for managing TransportUnit data, handling joins with trucks and employees.
    /// </summary>
    public class TransportUnitRepository : ITransportUnitRepository
    {
        private const string TableName = "transport_units";

        // This complex SELECT statement joins all necessary tables and uses aliases
        // for Dapper's multi-mapping feature.
        private const string SelectSql = @"
            SELECT
                tu.id AS Id,
                tu.unit_name AS UnitName,
                tu.status AS Status,
                
                t.id AS Id,
                t.model AS Model,
                t.license_plate AS LicensePlate,
                t.status AS Status,

                d.id AS Id,
                d.first_name AS FirstName,
                d.last_name AS LastName,
                d.contact_number AS ContactNumber,
                d.position AS Position,
                d.license_number AS LicenseNumber,
                d.status AS Status,

                a.id AS Id,
                a.first_name AS FirstName,
                a.last_name AS LastName,
                a.contact_number AS ContactNumber,
                a.position AS Position,
                a.license_number AS LicenseNumber,
                a.status AS Status
            FROM 
                transport_units tu
            LEFT JOIN 
                trucks t ON tu.truck_id = t.id
            LEFT JOIN 
                employees d ON tu.driver_id = d.id
            LEFT JOIN 
                employees a ON tu.assistant_id = a.id";

        // Dapper mapping function for combining the four objects from the query result.
        private TransportUnit MapUnit(TransportUnit unit, Truck truck, Employee driver, Employee assistant)
        {
            unit.Truck = truck;
            unit.Driver = driver;
            unit.Assistant = assistant;
            return unit;
        }

        // Helper to get a connection string, assuming DbConnectionHelper is accessible.
        private IDbConnection CreateConnection() => new MySqlConnection(DbConnectionHelper.GetConnectionString());

        public async Task<int> AddAsync(TransportUnit entity)
        {
            const string sql = @"
                INSERT INTO transport_units (unit_name, truck_id, driver_id, assistant_id, status)
                VALUES (@UnitName, @TruckId, @DriverId, @AssistantId, @Status);
                SELECT LAST_INSERT_ID();";

            // DbExecutor can be used here as it's a simple scalar query.
            return await DbExecutor.ExecuteScalarAsync<int>(sql, new
            {
                entity.UnitName,
                TruckId = entity.Truck.Id,
                DriverId = entity.Driver.Id,
                AssistantId = entity.Assistant.Id,
                Status = entity.Status.ToString()
            });
        }

        public async Task DeleteAsync(int id)
        {
            var sql = $"DELETE FROM {TableName} WHERE id = @Id;";
            await DbExecutor.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<IEnumerable<TransportUnit>> GetAllAsync(Dictionary<string, object>? filter = null, string? orderBy = null, bool isAscending = true)
        {
            var sqlBuilder = new StringBuilder(SelectSql);
            var parameters = new DynamicParameters();

            if (filter != null && filter.TryGetValue("SearchTerm", out var searchTermValue) && searchTermValue?.ToString() is string searchTerm && !string.IsNullOrWhiteSpace(searchTerm))
            {
                sqlBuilder.Append(" WHERE tu.unit_name LIKE @SearchQuery OR t.model LIKE @SearchQuery OR t.license_plate LIKE @SearchQuery");
                parameters.Add("SearchQuery", $"%{searchTerm}%");
            }

            // Add sorting logic here if needed

            // Bypassing DbExecutor for 4-object mapping by using a direct connection.
            using (var connection = CreateConnection())
            {
                return await connection.QueryAsync<TransportUnit, Truck, Employee, Employee, TransportUnit>(
                    sqlBuilder.ToString(),
                    MapUnit,
                    parameters,
                    splitOn: "Id,Id,Id"
                );
            }
        }

        public async Task<TransportUnit?> GetByIdAsync(int id)
        {
            var sql = $"{SelectSql} WHERE tu.id = @Id;";

            // Bypassing DbExecutor for 4-object mapping.
            using (var connection = CreateConnection())
            {
                var result = await connection.QueryAsync<TransportUnit, Truck, Employee, Employee, TransportUnit>(
                    sql,
                    MapUnit,
                    new { Id = id },
                    splitOn: "Id,Id,Id"
                );
                return result.FirstOrDefault();
            }
        }

        public async Task UpdateAsync(TransportUnit entity)
        {
            const string sql = @"
                UPDATE transport_units SET
                    unit_name = @UnitName,
                    truck_id = @TruckId,
                    driver_id = @DriverId,
                    assistant_id = @AssistantId,
                    status = @Status
                WHERE id = @Id;";

            await DbExecutor.ExecuteAsync(sql, new
            {
                entity.Id,
                entity.UnitName,
                TruckId = entity.Truck.Id,
                DriverId = entity.Driver.Id,
                AssistantId = entity.Assistant.Id,
                Status = entity.Status.ToString()
            });
        }

        public async Task<IEnumerable<TransportUnit>> GetByStatusAsync(ResourceStatus status)
        {
            var sql = $"{SelectSql} WHERE tu.status = @Status;";

            // Bypassing DbExecutor for 4-object mapping.
            using (var connection = CreateConnection())
            {
                return await connection.QueryAsync<TransportUnit, Truck, Employee, Employee, TransportUnit>(
                    sql,
                    MapUnit,
                    new { Status = status.ToString() },
                    splitOn: "Id,Id,Id"
                );
            }
        }

        public async Task UpdateStatusAsync(int unitId, ResourceStatus status)
        {
            var sql = $"UPDATE {TableName} SET status = @Status WHERE id = @Id;";
            await DbExecutor.ExecuteAsync(sql, new { Id = unitId, Status = status.ToString() });
        }
    }
}
