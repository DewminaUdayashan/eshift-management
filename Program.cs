using Dapper;
using eshift_management.Core.Services;
using eshift_management.Core.Services.Interfaces;
using eshift_management.Data.TypeHandlers;
using eshift_management.Repositories.Interfaces;
using eshift_management.Repositories.Services;
using eshift_management.Services.Implementations;
using eshift_management.Services.Interfaces;
using QuestPDF.Infrastructure;

namespace eshift_management
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            // --- IMPORTANT: Configure QuestPDF License ---
            QuestPDF.Settings.License = LicenseType.Community;

            // --- Seed the default admin user ---
            _ = EnsureAdminUserExists();

            SqlMapper.AddTypeHandler(new UserTypeHandler());
            SqlMapper.AddTypeHandler(new JobStatusTypeHandler());
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }

        /// <summary>
        /// A helper method to instantiate the user service and run the admin check.
        /// </summary>
        private static async Task EnsureAdminUserExists()
        {
            try
            {
                IUserRepository userRepository = new UserRepository();
                ICustomerRepository customerRepository = new CustomerRepository();
                IEmailService emailService = new EmailService();
                IUserService userService = new UserService(userRepository);
                ICustomerService customerService = new CustomerService(customerRepository);
                IAuthService authService = new AuthService(userService, customerService, emailService);
                await authService.EnsureAdminUserExistsAsync();
            }
            catch (Exception ex)
            {
                // If the database isn't available or something else goes wrong,
                // show an error message and close the application.
                MessageBox.Show($"A critical error occurred during application startup: {ex.Message}", "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}