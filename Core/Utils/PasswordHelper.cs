namespace eshift_management.Core.Security
{
    /// <summary>
    /// A helper class for hashing and verifying passwords using BCrypt.
    /// </summary>
    public static class PasswordHelper
    {
        /// <summary>
        /// Hashes a plain-text password.
        /// </summary>
        /// <param name="password">The plain-text password.</param>
        /// <returns>A salted and hashed password string.</returns>
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        /// <summary>
        /// Verifies a plain-text password against a stored hash.
        /// </summary>
        /// <param name="password">The plain-text password to check.</param>
        /// <param name="hashedPassword">The stored password hash.</param>
        /// <returns>True if the password is correct, otherwise false.</returns>
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
