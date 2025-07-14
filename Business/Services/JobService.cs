using eshift_management.Core.Repositories;
using eshift_management.Core.Services;
using eshift_management.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eshift_management.Services
{
    /// <summary>
    /// Provides business logic and operations for managing jobs.
    /// </summary>
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;

        /// <summary>
        /// Constructs the JobService with an injected job repository.
        /// </summary>
        /// <param name="jobRepository">The repository used to perform database operations.</param>
        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Job>> GetAllJobsAsync()
        {
            return await _jobRepository.GetAllAsync();
        }

        /// <inheritdoc/>
        public async Task<Job?> GetJobByIdAsync(int id)
        {
            return await _jobRepository.GetByIdAsync(id);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Job>> GetJobsByCustomerAsync(int customerId)
        {
            return await _jobRepository.GetJobsByCustomerAsync(customerId);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Job>> GetJobsByStatusAsync(JobStatus status)
        {
            return await _jobRepository.GetJobsByStatusAsync(status);
        }

        /// <inheritdoc/>
        public async Task<int> CreateJobAsync(Job job)
        {
            return await _jobRepository.AddAsync(job);
        }

        /// <inheritdoc/>
        public async Task UpdateJobAsync(Job job)
        {
            await _jobRepository.UpdateAsync(job);
        }

        /// <inheritdoc/>
        public async Task DeleteJobAsync(int id)
        {
            await _jobRepository.DeleteAsync(id);
        }

        /// <inheritdoc/>
        public async Task AssignTransportUnitAsync(int jobId, int unitId)
        {
            await _jobRepository.AssignTransportUnitAsync(jobId, unitId);
        }

        /// <inheritdoc/>
        public async Task UpdateJobStatusAsync(int jobId, JobStatus status, string? rejectionReason = null)
        {
            await _jobRepository.UpdateJobStatusAsync(jobId, status, rejectionReason);
        }
    }
}
