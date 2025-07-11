using FluentValidation;

namespace eshift_management.Models
{
    public class CustomerModel
    {
        public int? Id { get; set; }
        required public int? UserId { get; set; }
        required public string FirstName { get; set; }
        required public string LastName { get; set; }
        required public string Email { get; set; }
        required public string Phone { get; set; }
        required public string AddressLine { get; set; }
        required public string City { get; set; }
        required public string PostalCode { get; set; }

        // Read-only property for the full name
        public string FullName => $"{FirstName} {LastName}";

        // Property for the grid display
        public int? OngoingJobs { get; set; }
    }

    public class CustomerValidator : AbstractValidator<CustomerModel>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty().WithMessage("First name is required.");
            RuleFor(c => c.LastName).NotEmpty().WithMessage("Last name is required.");
            RuleFor(c => c.Email).NotEmpty().EmailAddress().WithMessage("A valid email is required.");
            RuleFor(c => c.Phone).NotEmpty().WithMessage("Phone number is required.");
            RuleFor(c => c.AddressLine).NotEmpty().WithMessage("Address is required.");
            RuleFor(c => c.City).NotEmpty().WithMessage("City is required.");
            RuleFor(c => c.PostalCode).NotEmpty().WithMessage("Postal code is required.");
        }
    }
}

