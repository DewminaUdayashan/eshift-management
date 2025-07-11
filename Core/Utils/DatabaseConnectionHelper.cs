using System.Configuration;

namespace eshift_management.Data
{
    public static class DbConnectionHelper
    {
        /// <summary>
        /// Retrieves the database connection string from the App.config file.
        /// </summary>
        /// <param name="name">The name of the connection string in App.config.</param>
        /// <returns>The database connection string.</returns>
        public static string GetConnectionString(string name = "DefaultConnection")
        {
            // This will look for a connection string named "DefaultConnection" in your App.config
            // Make sure to add your connection string there.
            string? connectionString = ConfigurationManager.ConnectionStrings[name]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ConfigurationErrorsException($"Connection string '{name}' not found in App.config.");
            }

            return connectionString;
        }
    }
}
