using FluentValidation;

namespace eshift_management.Models
{
    /// <summary>
    /// A model specifically for capturing data from the registration form.
    /// </summary>
    public class RegistrationModel
    {
        required public string FirstName { get; set; }
        required public string LastName { get; set; }
        required public string Email { get; set; }
        required public string Phone { get; set; }
        required public string AddressLine { get; set; }
        required public string City { get; set; }
        required public string PostalCode { get; set; }
        required public string Password { get; set; }
        required public string ConfirmPassword { get; set; }
    }

    /// <summary>
    /// Validator for the registration model.
    /// </summary>
    public class RegistrationValidator : AbstractValidator<RegistrationModel>
    {
        public RegistrationValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("A valid email is required.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone number is required.");
            RuleFor(x => x.AddressLine).NotEmpty().WithMessage("Address is required.");
            RuleFor(x => x.City).NotEmpty().WithMessage("City is required.");
            RuleFor(x => x.PostalCode).NotEmpty().WithMessage("Postal code is required.");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8).WithMessage("Password must be at least 8 characters.");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Passwords do not match.");
        }
    }
}
