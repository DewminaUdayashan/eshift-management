using Dapper;
using eshift_management.Core.Repositories;
using eshift_management.Data;
using eshift_management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshift_management.Repositories
{
    /// <summary>
    /// Repository implementation for managing job-related database operations using Dapper.
    /// </summary>
    public class JobRepository : IJobRepository
    {
        // Reusable SQL for joining jobs with customer and transport unit details.
        private const string JobSelectionSql = @"
            SELECT
                j.id AS Id, j.pickup_location AS PickupLocation, j.dropoff_location AS DropoffLocation,
                j.pickup_date AS PickupDate, j.load_size AS LoadSize, j.description AS Description,
                j.status AS Status, j.total_cost AS TotalCost, j.estimated_hours AS EstimatedHours,
                j.rejection_reason AS RejectionReason,
                c.user_id AS UserId, c.first_name AS FirstName, c.last_name AS LastName,
                u.email AS Email, c.phone_number AS Phone, c.address_line AS AddressLine,
                c.city AS City, c.postal_code AS PostalCode,
                tu.id AS Id, tu.unit_name AS UnitName
            FROM jobs j
            JOIN customers c ON j.customer_id = c.user_id
            JOIN users u ON c.user_id = u.id
            LEFT JOIN transport_units tu ON j.transport_unit_id = tu.id";

        /// <summary>
        /// A private mapping function to consolidate the logic for mapping related entities.
        /// </summary>
        private static Job MapJob(Job job, CustomerModel customer, TransportUnit unit)
        {
            job.Customer = customer;
            // Dapper populates a new object even if all columns are NULL.
            // Check a key property (like Id) to determine if it's a real entity.
            job.AssignedUnit = unit?.Id > 0 ? unit : null;
            return job;
        }

        public async Task<int> AddAsync(Job job)
        {
            const string sql = @"
                INSERT INTO jobs (customer_id, pickup_location, dropoff_location, pickup_date, load_size, description, status)
                VALUES (@CustomerId, @PickupLocation, @DropoffLocation, @PickupDate, @LoadSize, @Description, @Status);
                SELECT LAST_INSERT_ID();";

            var parameters = new
            {
                CustomerId = job.Customer.UserId,
                job.PickupLocation,
                job.DropoffLocation,
                job.PickupDate,
                job.LoadSize,
                job.Description,
                Status = job.Status.ToString()
            };

            return await DbExecutor.ExecuteScalarAsync<int>(sql, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            const string sql = "DELETE FROM jobs WHERE id = @Id";
            await DbExecutor.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<Job?> GetByIdAsync(int id)
        {
            var sql = $"{JobSelectionSql} WHERE j.id = @Id;";

            var queryResult = await DbExecutor.QueryAsync<Job, CustomerModel, TransportUnit, Job>(
                sql,
                MapJob,
                new { Id = id },
                splitOn: "UserId,Id"
            );

            return queryResult.FirstOrDefault();
        }

        public async Task<IEnumerable<Job>> GetAllAsync()
        {
            return await DbExecutor.QueryAsync<Job, CustomerModel, TransportUnit, Job>(
               JobSelectionSql,
               MapJob,
               splitOn: "UserId,Id"
           );
        }

        public async Task<IEnumerable<Job>> GetJobsByCustomerIdAsync(int customerId)
        {
            var sql = $"{JobSelectionSql} WHERE j.customer_id = @CustomerId;";

            return await DbExecutor.QueryAsync<Job, CustomerModel, TransportUnit, Job>(
                sql,
                MapJob,
                new { CustomerId = customerId },
                splitOn: "UserId,Id"
            );
        }

        public async Task UpdateAsync(Job job)
        {
            const string sql = @"
                UPDATE jobs SET
                    pickup_location = @PickupLocation,
                    dropoff_location = @DropoffLocation,
                    pickup_date = @PickupDate,
                    load_size = @LoadSize,
                    description = @Description,
                    status = @Status,
                    total_cost = @TotalCost,
                    estimated_hours = @EstimatedHours,
                    rejection_reason = @RejectionReason,
                    transport_unit_id = @TransportUnitId
                WHERE id = @Id;";

            var parameters = new
            {
                job.Id,
                job.PickupLocation,
                job.DropoffLocation,
                job.PickupDate,
                job.LoadSize,
                job.Description,
                Status = job.Status.ToString(),
                job.TotalCost,
                job.EstimatedHours,
                job.RejectionReason,
                TransportUnitId = job.AssignedUnit?.Id
            };

            await DbExecutor.ExecuteAsync(sql, parameters);
        }

        public async Task<IEnumerable<Job>> GetJobsByStatusAsync(JobStatus status)
        {
            var sql = $"{JobSelectionSql} WHERE j.status = @Status;";

            return await DbExecutor.QueryAsync<Job, CustomerModel, TransportUnit, Job>(
                sql,
                MapJob,
                new { Status = status.ToString() },
                splitOn: "UserId,Id"
            );
        }

        public async Task AssignTransportUnitAsync(int jobId, int unitId)
        {
            const string sql = @"
                UPDATE jobs SET
                    transport_unit_id = @UnitId,
                    status = 'Scheduled'
                WHERE id = @JobId AND status = 'Approved';";

            await DbExecutor.ExecuteAsync(sql, new { JobId = jobId, UnitId = unitId });
        }

        public async Task UpdateJobStatusAsync(int jobId, JobStatus status, string? rejectionReason = null)
        {
            const string sql = @"
                UPDATE jobs SET
                    status = @Status,
                    rejection_reason = @Reason
                WHERE id = @JobId;";

            await DbExecutor.ExecuteAsync(sql, new
            {
                JobId = jobId,
                Status = status.ToString(),
                Reason = rejectionReason
            });
        }

        public async Task<IEnumerable<Job>> GetJobsByCustomerAsync(int customerId)
        {
            var sql = $"{JobSelectionSql} WHERE j.customer_id = @CustomerId;";

            return await DbExecutor.QueryAsync<Job, CustomerModel, TransportUnit, Job>(
                sql,
                MapJob,
                new { CustomerId = customerId },
                splitOn: "UserId,Id"
            );
        }

        public async Task<IEnumerable<Job>> GetAllAsync(Dictionary<string, object>? filter = null, string? orderBy = null, bool isAscending = true)
        {
            // Start with the base query that joins all necessary tables.
            var sqlBuilder = new StringBuilder(JobSelectionSql);
            var parameters = new DynamicParameters();

            // --- Dynamic Filtering (WHERE clause) ---
            if (filter != null && filter.Any())
            {
                var conditions = new List<string>();
                foreach (var pair in filter)
                {
                    // Assuming the filter key maps directly to a column on the 'jobs' table (j).
                    // Example: a key "status" becomes "j.status = @status".
                    conditions.Add($"j.{pair.Key} = @{pair.Key}");
                    parameters.Add(pair.Key, pair.Value);
                }
                sqlBuilder.Append($" WHERE {string.Join(" AND ", conditions)}");
            }

            // --- Dynamic Sorting (ORDER BY clause) ---
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                // IMPORTANT: Whitelist sortable columns to prevent SQL injection.
                var allowedSortColumns = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "Id",
            "PickupDate",
            "Status",
            "TotalCost"
            // Add any other columns you want to allow sorting by.
        };

                if (allowedSortColumns.Contains(orderBy))
                {
                    // Map the property name to the actual database column name.
                    var dbColumnName = orderBy switch
                    {
                        "PickupDate" => "j.pickup_date",
                        "TotalCost" => "j.total_cost",
                        _ => $"j.{orderBy}" // Default case for direct mapping (e.g., Id, Status)
                    };

                    var direction = isAscending ? "ASC" : "DESC";
                    sqlBuilder.Append($" ORDER BY {dbColumnName} {direction}");
                }
            }

            var sql = sqlBuilder.ToString();

            // Execute the dynamically built query.
            return await DbExecutor.QueryAsync<Job, CustomerModel, TransportUnit, Job>(
                sql,
                MapJob,
                parameters,
                splitOn: "UserId,Id"
            );
        }
    }
}