using eshift_management.Core.Repositories;
using eshift_management.Core.Services;
using eshift_management.Models;
using eshift_management.Repositories.Interfaces;

namespace eshift_management.Services
{
    /// <summary>
    /// Implements the logic for fetching data for the admin dashboard.
    /// </summary>
    public class DashboardService : IDashboardService
    {
        private readonly IJobRepository _jobRepository;
        private readonly ITruckRepository _truckRepository;
        private readonly ICustomerRepository _customerRepository;

        public DashboardService(IJobRepository jobRepository, ITruckRepository truckRepository, ICustomerRepository customerRepository)
        {
            _jobRepository = jobRepository;
            _truckRepository = truckRepository;
            _customerRepository = customerRepository;
        }

        public async Task<DashboardStats> GetDashboardStatsAsync()
        {
            // Run all count queries in parallel for maximum efficiency
            var ongoingJobsTask = _jobRepository.GetAllAsync(new Dictionary<string, object> { { "Status", JobStatus.OnGoing.ToString() } });
            var pendingJobsTask = _jobRepository.GetAllAsync(new Dictionary<string, object> { { "Status", JobStatus.Pending.ToString() } });
            var availableTrucksTask = _truckRepository.GetByStatusAsync(ResourceStatus.Available);
            var activeCustomersTask = _customerRepository.GetAllAsync();

            await Task.WhenAll(ongoingJobsTask, pendingJobsTask, availableTrucksTask, activeCustomersTask);

            return new DashboardStats
            {
                OngoingJobs = ongoingJobsTask.Result.Count(),
                PendingJobs = pendingJobsTask.Result.Count(),
                AvailableTrucks = availableTrucksTask.Result.Count(),
                ActiveCustomers = activeCustomersTask.Result.Count()
            };
        }

        public async Task<IEnumerable<Job>> GetUpcomingJobsAsync()
        {
            return await _jobRepository.GetJobsByStatusAsync(JobStatus.Scheduled);
        }
    }
}