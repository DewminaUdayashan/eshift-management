using eshift_management.Core.Repositories;
using eshift_management.Core.Services;
using eshift_management.Models;
using eshift_management.Repositories.Interfaces;

namespace eshift_management.Services
{
    /// <summary>
    /// Implements the logic for fetching and preparing data for various business reports.
    /// </summary>
    public class ReportService : IReportService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ITruckRepository _truckRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IJobRepository _jobRepository;

        /// <summary>
        /// Constructs the ReportService with injected repositories.
        /// </summary>
        public ReportService(ICustomerRepository customerRepository, ITruckRepository truckRepository, IEmployeeRepository employeeRepository, IJobRepository jobRepository)
        {
            _customerRepository = customerRepository;
            _truckRepository = truckRepository;
            _employeeRepository = employeeRepository;
            _jobRepository = jobRepository;
        }

        public async Task<IEnumerable<CustomerModel>> GetCustomerReportDataAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task<(IEnumerable<Truck> Trucks, IEnumerable<Employee> Employees)> GetResourceReportDataAsync()
        {
            var trucks = await _truckRepository.GetAllAsync();
            var employees = await _employeeRepository.GetAllAsync();
            return (trucks, employees);
        }

        public async Task<IEnumerable<Job>> GetOngoingJobsReportDataAsync()
        {
            // Fetch both scheduled and ongoing jobs and combine them.
            var scheduledJobs = await _jobRepository.GetJobsByStatusAsync(JobStatus.Scheduled);
            var ongoingJobs = await _jobRepository.GetJobsByStatusAsync(JobStatus.OnGoing);
            return scheduledJobs.Concat(ongoingJobs);
        }

        public async Task<IEnumerable<Job>> GetRevenueReportDataAsync()
        {
            // Fetch only completed jobs for the revenue report.
            return await _jobRepository.GetJobsByStatusAsync(JobStatus.Completed);
        }
    }
}
