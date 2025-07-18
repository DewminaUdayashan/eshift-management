using System.Threading.Tasks;

namespace eshift_management.Core.Services.Interfaces
{
    /// <summary>
    /// Defines the contract for a service that sends emails.
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Sends an email asynchronously.
        /// </summary>
        /// <param name="toEmail">The recipient's email address.</param>
        /// <param name="subject">The subject of the email.</param>
        /// <param name="htmlBody">The body of the email, which can contain HTML.</param>
        /// <returns>A task that represents the asynchronous send operation.</returns>
        Task SendEmailAsync(string toEmail, string subject, string htmlBody);


        /// <summary>
        /// Creates a styled HTML email body.
        /// </summary>
        string GetEmailHtmlTemplate(string title, string content, string customerName);
    }
}
