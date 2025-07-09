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
        required public string FirstName { get; set; }
        required public string LastName { get; set; }
        required public EmployeePosition Position { get; set; }
        required public string ContactNumber { get; set; }
        required public string LicenseNumber { get; set; } // Will be blank for Assistants
        required public ResourceStatus Status { get; set; }

        // Read-only property for convenience
        public string FullName => $"{FirstName} {LastName}";
    }

    public class TruckValidator : AbstractValidator<Truck>
    {
        public TruckValidator()
        {
            RuleFor(t => t.Model).NotEmpty().WithMessage("Model is required.");
            RuleFor(t => t.LicensePlate).NotEmpty().WithMessage("License plate is required.");
        }
    }

    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(e => e.FirstName).NotEmpty().WithMessage("First name is required.");
            RuleFor(e => e.LastName).NotEmpty().WithMessage("Last name is required.");
            RuleFor(e => e.ContactNumber).NotEmpty().WithMessage("Contact number is required.");
            RuleFor(e => e.Position).IsInEnum().WithMessage("A valid position is required.");

            // LicenseNumber is required only when the position is 'Driver'
            RuleFor(e => e.LicenseNumber)
                .NotEmpty().WithMessage("License number is required for drivers.")
                .When(e => e.Position == EmployeePosition.Driver);
        }
    }
}