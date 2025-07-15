using eshift_management.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eshift_management.Core.Repositories
{
    /// <summary>
    /// Repository interface for accessing and manipulating job-related data.
    /// </summary>
    public interface IJobRepository : IRepository<Job>
    {
        /// <summary>
        /// Gets all jobs submitted by a specific customer.
        /// </summary>
        /// <param name="customerId">The user ID of the customer.</param>
        /// <returns>A collection of jobs submitted by the customer.</returns>
        Task<IEnumerable<Job>> GetJobsByCustomerAsync(int customerId);

        /// <summary>
        /// Gets all jobs with a specific status.
        /// </summary>
        /// <param name="status">The status to filter by (e.g., "Pending").</param>
        /// <returns>A collection of jobs with the given status.</returns>
        Task<IEnumerable<Job>> GetJobsByStatusAsync(JobStatus status);

        /// <summary>
        /// Assigns a transport unit to a job.
        /// </summary>
        /// <param name="jobId">The ID of the job.</param>
        /// <param name="unitId">The ID of the transport unit to assign.</param>
        Task AssignTransportUnitAsync(int jobId, int unitId);

        /// <summary>
        /// Updates the job status.
        /// </summary>
        /// <param name="jobId">The job ID.</param>
        /// <param name="status">The new job status.</param>
        /// <param name="rejectionReason">Optional rejection reason (used when status is Rejected).</param>
        Task UpdateJobStatusAsync(int jobId, JobStatus status, string? rejectionReason = null);


        /// <summary>
        /// Checks if a transport unit is scheduled on a specific date.
        /// </summary>
        /// <param name="date">The date that needs to be checked</param>
        /// <param name="unitId">Transport unit ID</param>
        /// <param name="excludeJobId">Job ID if needs to be excluded</param>
        Task<bool> IsUnitScheduledOnDateAsync(int unitId, DateTime date, int? excludeJobId = null);
    }
}
