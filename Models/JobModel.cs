using FluentValidation;

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
    public class JobValidator : AbstractValidator<Job>
    {
        public JobValidator()
        {
            RuleFor(j => j.PickupLocation).NotEmpty().WithMessage("Pickup address is required.");
            RuleFor(j => j.DropoffLocation).NotEmpty().WithMessage("Dropoff address is required.");
            RuleFor(j => j.LoadSize).NotEmpty().WithMessage("Load size must be selected.");
            RuleFor(j => j.PickupDate).GreaterThan(DateTime.Now).WithMessage("Pickup date must be in the future.");
        }
    }
}