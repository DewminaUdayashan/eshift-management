using eshift_management.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eshift_management.Core.Services
{
    /// <summary>
    /// Defines the contract for generating data sets for various reports.
    /// </summary>
    public interface IReportService
    {
        /// <summary>
        /// Gets all customer data required for the customer report.
        /// </summary>
        /// <returns>A collection of all customers.</returns>
        Task<IEnumerable<CustomerModel>> GetCustomerReportDataAsync();

        /// <summary>
        /// Gets all resource data (trucks and employees) for the resource report.
        /// </summary>
        /// <returns>A tuple containing a list of trucks and a list of employees.</returns>
        Task<(IEnumerable<Truck> Trucks, IEnumerable<Employee> Employees)> GetResourceReportDataAsync();

        /// <summary>
        /// Gets all jobs that are currently scheduled or ongoing.
        /// </summary>
        /// <returns>A collection of jobs with a 'Scheduled' or 'OnGoing' status.</returns>
        Task<IEnumerable<Job>> GetOngoingJobsReportDataAsync();

        /// <summary>
        /// Gets all completed jobs to calculate revenue.
        /// </summary>
        /// <returns>A collection of jobs with a 'Completed' status.</returns>
        Task<IEnumerable<Job>> GetRevenueReportDataAsync();
    }
}
