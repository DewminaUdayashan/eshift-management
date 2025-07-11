namespace eshift_management.Models
{
    /// <summary>
    /// Represents a user record in the database for authentication purposes.
    /// </summary>
    public class UserModel
    {
        public int? Id { get; set; }
        required public string Email { get; set; }
        required public string PasswordHash { get; set; }
        required public UserType UserType { get; set; }
        required public bool IsEmailVerified { get; set; }
        public string? temporaryOTP { get; set; }
    }
}