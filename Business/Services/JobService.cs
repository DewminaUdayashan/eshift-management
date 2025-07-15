using eshift_management.Core.Repositories;
using eshift_management.Core.Services;
using eshift_management.Models;

namespace eshift_management.Services
{
    /// <summary>
    /// Provides business logic for managing jobs. This single class implements
    /// role-specific interfaces for both Admins and Customers.
    /// </summary>
    public class JobService : IAdminJobService, ICustomerJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly ITransportUnitRepository _unitRepository;

        /// <summary>
        /// Constructs the JobService with injected repositories.
        /// </summary>
        public JobService(IJobRepository jobRepository, ITransportUnitRepository unitRepository)
        {
            _jobRepository = jobRepository;
            _unitRepository = unitRepository;
        }

        public Task<IEnumerable<Job>> GetAllJobsAsync(Dictionary<string, object>? filter = null, string? orderBy = null, bool isAscending = true)
        {
            return _jobRepository.GetAllAsync(filter, orderBy, isAscending);
        }

        public Task<Job?> GetJobByIdAsync(int id)
        {
            return _jobRepository.GetByIdAsync(id);
        }

        // --- IAdminJobService Methods ---

        public async Task ApproveJobAsync(int jobId, decimal totalCost, int estimatedHours)
        {
            var job = await _jobRepository.GetByIdAsync(jobId) ?? throw new KeyNotFoundException("Job not found.");
            if (job.Status != JobStatus.Pending) throw new InvalidOperationException("Only pending jobs can be approved.");

            job.TotalCost = totalCost;
            job.EstimatedHours = estimatedHours;
            job.Status = JobStatus.Approved;
            await _jobRepository.UpdateAsync(job);
        }

        public async Task RejectJobAsync(int jobId, string reason)
        {
            await _jobRepository.UpdateJobStatusAsync(jobId, JobStatus.Rejected, reason);
        }

        public async Task AssignTransportUnitAsync(int jobId, int unitId)
        {
            var job = await _jobRepository.GetByIdAsync(jobId) ?? throw new KeyNotFoundException("Job not found.");
            var unit = await _unitRepository.GetByIdAsync(unitId) ?? throw new KeyNotFoundException("Unit not found.");

            if (job.Status != JobStatus.Approved && job.Status != JobStatus.Scheduled)
                throw new InvalidOperationException("A unit can only be assigned to an approved or already scheduled job.");

            if (unit.Status != ResourceStatus.Available && job.AssignedUnit?.Id != unitId)
                throw new InvalidOperationException("The selected unit is not available.");

            if (job.AssignedUnit != null && job.AssignedUnit.Id != unitId)
            {
                await _unitRepository.UpdateStatusAsync(job.AssignedUnit.Id, ResourceStatus.Available);
            }

            await _jobRepository.AssignTransportUnitAsync(jobId, unitId);
            await _unitRepository.UpdateStatusAsync(unitId, ResourceStatus.Assigned);
        }

        public async Task DispatchJobAsync(int jobId)
        {
            await _jobRepository.UpdateJobStatusAsync(jobId, JobStatus.OnGoing);
        }

        public async Task CompleteJobAsync(int jobId)
        {
            var job = await _jobRepository.GetByIdAsync(jobId) ?? throw new KeyNotFoundException("Job not found.");
            if (job.AssignedUnit == null) throw new InvalidOperationException("Cannot complete a job with no assigned unit.");

            await _jobRepository.UpdateJobStatusAsync(jobId, JobStatus.Completed);
            await _unitRepository.UpdateStatusAsync(job.AssignedUnit.Id, ResourceStatus.Available);
        }

        public async Task CancelJobAsync(int jobId)
        {
            var job = await _jobRepository.GetByIdAsync(jobId) ?? throw new KeyNotFoundException("Job not found.");
            if (job.AssignedUnit != null)
            {
                await _unitRepository.UpdateStatusAsync(job.AssignedUnit.Id, ResourceStatus.Available);
            }
            await _jobRepository.UpdateJobStatusAsync(jobId, JobStatus.Canceled);
        }

        // --- ICustomerJobService Methods ---

        public Task<IEnumerable<Job>> GetJobsByCustomerAsync(int customerId)
        {
            return _jobRepository.GetJobsByCustomerAsync(customerId);
        }

        public Task<int> CreateJobAsync(Job job)
        {
            // Customers can only create jobs with a 'Pending' status.
            job.Status = JobStatus.Pending;
            return _jobRepository.AddAsync(job);
        }

        public async Task UpdateJobAsync(Job job)
        {
            // Business Rule: A customer can only update a job if it's still pending.
            var existingJob = await _jobRepository.GetByIdAsync(job.Id) ?? throw new KeyNotFoundException("Job not found.");
            if (existingJob.Status != JobStatus.Pending)
            {
                throw new InvalidOperationException("You can no longer edit this job as it has already been reviewed by an administrator.");
            }
            await _jobRepository.UpdateAsync(job);
        }

        public async Task CancelPendingJobAsync(int jobId, int customerId)
        {
            var job = await _jobRepository.GetByIdAsync(jobId) ?? throw new KeyNotFoundException("Job not found.");

            // Security Check: Ensure the customer owns this job and it's pending.
            if (job.Customer.UserId != customerId)
            {
                throw new UnauthorizedAccessException("You are not authorized to cancel this job.");
            }
            if (job.Status != JobStatus.Pending)
            {
                throw new InvalidOperationException("Only pending jobs can be canceled.");
            }

            await _jobRepository.UpdateJobStatusAsync(jobId, JobStatus.Canceled);
        }
    }
}
