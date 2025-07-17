using eshift_management.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eshift_management.Core.Services
{
    /// <summary>
    /// Defines job-related operations available to an Administrator.
    /// This interface handles the entire lifecycle of a job from an admin's perspective.
    /// </summary>
    public interface IAdminJobService
    {
        /// <summary>
        /// Retrieves all jobs with detailed information, with optional filtering and sorting.
        /// </summary>
        /// <param name="filter">A dictionary for filtering. Supports 'SearchTerm', 'Status', 'StartDate', and 'EndDate'.</param>
        /// <param name="orderBy">The property to sort by.</param>
        /// <param name="isAscending">The sort direction.</param>
        /// <returns>A collection of fully populated jobs.</returns>
        Task<IEnumerable<Job>> GetAllJobsAsync(Dictionary<string, object>? filter = null, string? orderBy = null, bool isAscending = true);

        /// <summary>
        /// Retrieves a single, fully populated job by its ID.
        /// </summary>
        /// <param name="id">The ID of the job.</param>
        /// <returns>A job object, or null if not found.</returns>
        Task<Job?> GetJobByIdAsync(int id);

        /// <summary>
        /// Approves a pending job and sets its initial cost and estimated hours.
        /// </summary>
        /// <param name="jobId">The ID of the job to approve.</param>
        /// <param name="totalCost">The calculated total cost for the job.</param>
        /// <param name="estimatedHours">The estimated hours required to complete the job.</param>
        Task ApproveJobAsync(int jobId, decimal totalCost, int estimatedHours, int customerId);

        /// <summary>
        /// Rejects a pending job with a specific reason.
        /// </summary>
        /// <param name="jobId">The ID of the job to reject.</param>
        /// <param name="reason">The reason for the rejection.</param>
        Task RejectJobAsync(int jobId, string reason, int customerId);

        /// <summary>
        /// Assigns a transport unit to an approved job, or changes the unit for a scheduled job.
        /// This action also updates the status of the involved transport units.
        /// </summary>
        /// <param name="jobId">The ID of the job.</param>
        /// <param name="unitId">The ID of the transport unit to assign.</param>
        Task AssignTransportUnitAsync(int jobId, int unitId, bool forceAssignment = false);

        /// <summary>
        /// Dispatches a scheduled job, changing its status to 'OnGoing'.
        /// </summary>
        /// <param name="jobId">The ID of the job to dispatch.</param>
        Task DispatchJobAsync(int jobId, int customerId);

        /// <summary>
        /// Completes an ongoing job and frees up the assigned transport unit, making it available again.
        /// </summary>
        /// <param name="jobId">The ID of the job to complete.</param>
        Task CompleteJobAsync(int jobId, int customerId);

        /// <summary>
        /// Cancels a job at any stage (Approved, Scheduled), freeing up the assigned transport unit if applicable.
        /// </summary>
        /// <param name="jobId">The ID of the job to cancel.</param>
        Task CancelJobAsync(int jobId);
    }

    /// <summary>
    /// Defines job-related operations available to a Customer.
    /// This interface provides a secure, limited set of actions for customers.
    /// </summary>
    public interface ICustomerJobService
    {
        /// <summary>
        /// Retrieves all jobs submitted by a specific customer.
        /// </summary>
        /// <param name="customerId">The ID of the customer whose jobs are to be retrieved.</param>
        /// <returns>A collection of the customer's jobs.</returns>
        Task<IEnumerable<Job>> GetJobsByCustomerAsync(int customerId);

        /// <summary>
        /// Retrieves a single job by its ID, ensuring it belongs to the customer (validation done in implementation).
        /// </summary>
        /// <param name="id">The ID of the job.</param>
        /// <returns>A job object, or null if not found.</returns>
        Task<Job?> GetJobByIdAsync(int id);

        /// <summary>
        /// Creates a new job request and submits it for admin review.
        /// </summary>
        /// <param name="job">The job object containing all necessary details.</param>
        /// <returns>The ID of the newly created job.</returns>
        Task<int> CreateJobAsync(Job job);

        /// <summary>
        /// Updates an existing job, but only if it is still in 'Pending' status.
        /// </summary>
        /// <param name="job">The job object with updated information.</param>
        Task UpdateJobAsync(Job job);

        /// <summary>
        /// Allows a customer to cancel their own job, but only if it is still in 'Pending' status.
        /// </summary>
        /// <param name="jobId">The ID of the job to cancel.</param>
        /// <param name="customerId">The ID of the customer making the request, for authorization.</param>
        Task CancelPendingJobAsync(int jobId, int customerId);
    }
}
