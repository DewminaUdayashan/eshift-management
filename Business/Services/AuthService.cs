using eshift_management.Core.Security;
using eshift_management.Core.Services.Interfaces;
using eshift_management.Models;
using eshift_management.Repositories.Interfaces;
using eshift_management.Services.Interfaces;
using System.Threading.Tasks;

namespace eshift_management.Services.Implementations
{
    /// <summary>
    /// Provides authentication services including registration and login functionality.
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailService _emailService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthService"/> class.
        /// </summary>
        /// <param name="userRepository">The repository for user operations.</param>
        /// <param name="customerRepository">The repository for customer operations.</param>
        public AuthService(
            IUserRepository userRepository,
            ICustomerRepository customerRepository,
            IEmailService emailService)
        {
            _userRepository = userRepository;
            _customerRepository = customerRepository;
            _emailService = emailService;
        }

        /// <inheritdoc />
        public async Task<(bool IsSuccess, string? ErrorMessage, UserModel? user)> RegisterAsync(UserModel user, CustomerModel customer)
        {
            // Check if user already exists
            var existing = await _userRepository.FindByEmailAsync(user.Email);
            if (existing != null)
            {
                return (false, "Email is already registered.", null);
            }

            // Hash password
            user.PasswordHash = PasswordHelper.HashPassword(user.PasswordHash);
            user.IsEmailVerified = false;

            // Create user
            int userId = await _userRepository.AddAsync(user);

            // Link and create customer
            customer.UserId = userId;
            await _customerRepository.AddAsync(customer);
            var otp = GenerateOtp();

            // Send verification email
            await _emailService.SendEmailAsync(
      toEmail: user.Email,
      subject: "Your e-Shift OTP Code",
      htmlBody: $"<h3>Your verification code is: <strong>{otp}</strong></h3>");

            var newUser = await _userRepository.GetByIdAsync(userId);
            newUser.temporaryOTP = otp;

            return (true, null, newUser);
        }

        /// <inheritdoc />
        public async Task<(bool IsSuccess, string? ErrorMessage, UserModel? User)> LoginAsync(string email, string password)
        {
            var user = await _userRepository.FindByEmailAsync(email);
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
    }
}
