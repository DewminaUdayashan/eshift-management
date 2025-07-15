using eshift_management.Models;

namespace eshift_management.Core.Services
{
    /// <summary>
    /// Defines the contract for fetching data specifically for the admin dashboard.
    /// </summary>
    public interface IDashboardService
    {
        /// <summary>
        /// Gets all the key statistics for the dashboard summary cards.
        /// </summary>
        /// <returns>A model containing all dashboard counts.</returns>
        Task<DashboardStats> GetDashboardStatsAsync();

        /// <summary>
        /// Gets a list of upcoming jobs (Scheduled status).
        /// </summary>
        /// <returns>A collection of scheduled jobs.</returns>
        Task<IEnumerable<Job>> GetUpcomingJobsAsync();
    }
}