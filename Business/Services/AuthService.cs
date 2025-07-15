using eshift_management.Core.Security;
using eshift_management.Core.Services.Interfaces;
using eshift_management.Models;
using eshift_management.Repositories.Interfaces;
using eshift_management.Repositories.Services;
using eshift_management.Services.Interfaces;
using Microsoft.VisualBasic.ApplicationServices;

namespace eshift_management.Services.Implementations
{
    /// <summary>
    /// Provides authentication services including registration and login functionality.
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ICustomerService _customerService;
        private readonly IEmailService _emailService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthService"/> class.
        /// </summary>
        /// <param name="userService">The service for user operations.</param>
        /// <param name="customerService">The service for customer operations.</param>
        public AuthService(
            IUserService userService,
            ICustomerService customerService,
            IEmailService emailService)
        {
            _userService = userService;
            _customerService = customerService;
            _emailService = emailService;
        }

        /// <inheritdoc />
        public async Task<(bool IsSuccess, string? ErrorMessage, UserModel? user)> RegisterAsync(UserModel user, CustomerModel customer)
        {
            // Check if user already exists
            var existing = await _userService.FindByEmailAsync(user.Email);
            if (existing != null)
            {
                return (false, "Email is already registered.", null);
            }

            // Hash password
            user.PasswordHash = PasswordHelper.HashPassword(user.PasswordHash);
            user.IsEmailVerified = false;

            // Create user
            int userId = await _userService.AddAsync(user);

            // Link and create customer
            customer.UserId = userId;
            await _customerService.AddAsync(customer);
            var otp = GenerateOtp();

            // Send verification email
            await _emailService.SendEmailAsync(
      toEmail: user.Email,
      subject: "Your e-Shift OTP Code",
      htmlBody: $"<h3>Your verification code is: <strong>{otp}</strong></h3>");

            var newUser = await _userService.GetByIdAsync(userId);
            newUser.temporaryOTP = otp;

            return (true, null, newUser);
        }

        /// <inheritdoc />
        public async Task<(bool IsSuccess, string? ErrorMessage, UserModel? User)> LoginAsync(string email, string password)
        {
            var user = await _userService.FindByEmailAsync(email);
            if (user == null)
            {
                return (false, "Invalid email or password.", null);
            }

            bool passwordMatch = PasswordHelper.VerifyPassword(password, user.PasswordHash);
            if (!passwordMatch)
            {
                return (false, "Invalid email or password.", null);
            }

            if (!user.IsEmailVerified)
            {
                return (false, "Email is not verified.", null);
            }

            return (true, null, user);
        }

        private static string GenerateOtp()
        {
            var random = new Random();
            return random.Next(100000, 999999).ToString(); // 6-digit OTP
        }


        /// <inheritdoc/>
        public async Task EnsureAdminUserExistsAsync()
        {
            const string adminEmail = "admin@eshift.com";
            const string adminPassword = "Admin@eshift123";

            // 1. Check if the admin user already exists.
            var existingAdmin = await _userService.FindByEmailAsync(adminEmail);

            // 2. If the user does not exist, create them.
            if (existingAdmin == null)
            {
                var adminUser = new UserModel
                {
                    Email = adminEmail,
                    UserType = UserType.Admin,
                    IsEmailVerified = true,
                    PasswordHash = PasswordHelper.HashPassword(adminPassword)
                };

                await _userService.AddAsync(adminUser);
            }
        }
    }
}
