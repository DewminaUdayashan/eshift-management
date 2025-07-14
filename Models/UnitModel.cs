using FluentValidation;

namespace eshift_management.Models
{
    public class TransportUnit
    {
        required public int Id { get; set; }
        required public string UnitName { get; set; }
        required public Truck Truck { get; set; }
        required public Employee Driver { get; set; }
        required public Employee Assistant { get; set; }
        required public ResourceStatus Status { get; set; }

        // Holds the Job ID if Status is Assigned, otherwise empty
        required public string AssignedJobId { get; set; }
    }

    public class UnitValidator : AbstractValidator<TransportUnit>
    {
        public UnitValidator()
        {
            RuleFor(u => u.UnitName).NotEmpty().WithMessage("A unit name is required.");
            RuleFor(u => u.Truck).NotNull().WithMessage("A truck must be selected.");
            RuleFor(u => u.Driver).NotNull().WithMessage("A driver must be selected.");
            RuleFor(u => u.Assistant).NotNull().WithMessage("An assistant must be selected.");
        }
    }
}