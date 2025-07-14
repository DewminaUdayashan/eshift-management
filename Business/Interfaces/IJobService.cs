using eshift_management.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eshift_management.Core.Services
{
    /// <summary>
    /// Defines the contract for job-related business operations.
    /// </summary>
    public interface IJobService
    {
        /// <summary>
        /// Retrieves all jobs with detailed information (customer, unit, etc.).
        /// </summary>
        Task<IEnumerable<Job>> GetAllJobsAsync();

        /// <summary>
        /// Retrieves a single job by its ID.
        /// </summary>
        /// <param name="id">The ID of the job.</param>
        Task<Job?> GetJobByIdAsync(int id);

        /// <summary>
        /// Retrieves all jobs for a specific customer.
        /// </summary>
        /// <param name="customerId">The ID of the customer.</param>
        Task<IEnumerable<Job>> GetJobsByCustomerAsync(int customerId);

        /// <summary>
        /// Retrieves all jobs filtered by their status.
        /// </summary>
        /// <param name="status">The job status to filter by.</param>
        Task<IEnumerable<Job>> GetJobsByStatusAsync(JobStatus status);

        /// <summary>
        /// Creates a new job entry.
        /// </summary>
        /// <param name="job">The job data to insert.</param>
        /// <returns>The newly created job ID.</returns>
        Task<int> CreateJobAsync(Job job);

        /// <summary>
        /// Updates an existing job entry.
        /// </summary>
        /// <param name="job">The job data with updates.</param>
        Task UpdateJobAsync(Job job);

        /// <summary>
        /// Deletes a job by its ID.
        /// </summary>
        /// <param name="id">The ID of the job to delete.</param>
        Task DeleteJobAsync(int id);

        /// <summary>
        /// Assigns a transport unit to an approved job.
        /// </summary>
        /// <param name="jobId">The ID of the job.</param>
        /// <param name="unitId">The ID of the transport unit to assign.</param>
        Task AssignTransportUnitAsync(int jobId, int unitId);

        /// <summary>
        /// Updates the status of a job, including setting rejection reasons if needed.
        /// </summary>
        /// <param name="jobId">The ID of the job.</param>
        /// <param name="status">The new status of the job.</param>
        /// <param name="rejectionReason">The reason for rejection, if applicable.</param>
        Task UpdateJobStatusAsync(int jobId, JobStatus status, string? rejectionReason = null);
    }
}
