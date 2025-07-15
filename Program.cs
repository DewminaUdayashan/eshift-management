using Dapper;
using eshift_management.Data.TypeHandlers;
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

            SqlMapper.AddTypeHandler(new UserTypeHandler());
            SqlMapper.AddTypeHandler(new JobStatusTypeHandler());
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}