namespace eshift_management.Models
{
    /// <summary>
    /// A model to hold the aggregated statistics for the dashboard.
    /// </summary>
    public class DashboardStats
    {
        public int OngoingJobs { get; set; }
        public int AvailableTrucks { get; set; }
        public int ActiveCustomers { get; set; }
        public int PendingJobs { get; set; }
    }
}