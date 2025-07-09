namespace eshift_management.Models
{
    public class Job
    {
        required public string Id { get; set; }
        required public CustomerModel Customer { get; set; }
        required public string PickupLocation { get; set; }
        required public string DropoffLocation { get; set; }
        required public DateTime PickupDate { get; set; }
        required public string LoadSize { get; set; }
        required public string Description { get; set; }
        required public JobStatus Status { get; set; }

        // Fields for admin
        public decimal TotalCost { get; set; }
        public int EstimatedHours { get; set; }
        public string? RejectionReason { get; set; }
        public TransportUnit? AssignedUnit { get; set; }
    }
}