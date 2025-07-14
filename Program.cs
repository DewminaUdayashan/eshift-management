using Dapper;
using eshift_management.Data.TypeHandlers;

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
            SqlMapper.AddTypeHandler(new UserTypeHandler());
            SqlMapper.AddTypeHandler(new JobStatusTypeHandler());
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}