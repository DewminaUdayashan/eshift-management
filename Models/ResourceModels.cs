using FluentValidation;

namespace eshift_management.Models
{

    // Truck model
    public class Truck
    {
        required public string Id { get; set; }
        required public string Model { get; set; }
        required public string LicensePlate { get; set; }
        required public ResourceStatus Status { get; set; }
    }

    // Model to handle both Drivers and Assistants
    public class Employee
    {
        required public string Id { get; set; }
        required public string Name { get; set; }
        required public EmployeePosition Position { get; set; }
        required public string ContactNumber { get; set; }
        required public string LicenseNumber { get; set; } // Will be blank for Assistants
        required public ResourceStatus Status { get; set; }
    }
    public class TruckValidator : AbstractValidator<Truck>
    {
        public TruckValidator()
        {
            RuleFor(t => t.Model).NotEmpty().WithMessage("Model is required.");
            RuleFor(t => t.LicensePlate).NotEmpty().WithMessage("License plate is required.");
        }
    }
}