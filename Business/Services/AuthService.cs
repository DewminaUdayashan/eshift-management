using eshift_management.Core.Security;
using eshift_management.Core.Services.Interfaces;
using eshift_management.Models;
using eshift_management.Repositories.Interfaces;
using eshift_management.Services.Interfaces;
using System;
using System.Threading.Tasks;

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
        /// <param name="emailService">The service for sending emails.</param>
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

            // Hash password and set initial user state
            user.PasswordHash = PasswordHelper.HashPassword(user.PasswordHash);
            user.IsEmailVerified = false;

            // Create user
            int userId = await _userService.AddAsync(user);

            // Link and create customer
            customer.UserId = userId;
            await _customerService.AddAsync(customer);
            var otp = GenerateOtp();

            // --- Updated Email Logic ---
            string subject = "Your E-Shift Verification Code";
            string content = $@"
                <p>Welcome to E-Shift Movers! To complete your registration, please use the following One-Time Password (OTP). This code is valid for 10 minutes.</p>
                <h2 style='text-align:center; font-size: 36px; letter-spacing: 4px; color: #0D47A1;'>{otp}</h2>
                <p>If you did not request this code, please ignore this email.</p>";

            // Use the template to create the final HTML body
            string htmlBody = _emailService.GetEmailHtmlTemplate("Verify Your Email", content, customer.FirstName);

            // Send verification email
            await _emailService.SendEmailAsync(
                toEmail: user.Email,
                subject: subject,
                htmlBody: htmlBody);

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

        /// <summary>
        /// Generates a random 6-digit OTP.
        /// </summary>
        private static string GenerateOtp()
        {
            var random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        /// <inheritdoc/>
        public async Task EnsureAdminUserExistsAsync()
        {
            const string adminEmail = "admin@eshift.com";
            const string adminPassword = "Admin@eshift123";

            var existingAdmin = await _userService.FindByEmailAsync(adminEmail);

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
