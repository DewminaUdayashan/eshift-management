using eshift_management.Core.Services.Interfaces;
using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eshift_management.Core.Services
{
    public class EmailService : IEmailService
    {
        private readonly string _host;
        private readonly int _port;
        private readonly string _user;
        private readonly string _pass;

        public EmailService()
        {
            // Load credentials from App.config
            _host = ConfigurationManager.AppSettings["SmtpHost"];
            _port = int.Parse(ConfigurationManager.AppSettings["SmtpPort"]);
            _user = ConfigurationManager.AppSettings["SmtpUser"];
            _pass = ConfigurationManager.AppSettings["SmtpPass"];

            if (string.IsNullOrEmpty(_host) || string.IsNullOrEmpty(_user) || string.IsNullOrEmpty(_pass))
            {
                throw new ConfigurationErrorsException("SMTP settings are not configured in App.config.");
            }
        }

        public async Task SendEmailAsync(string toEmail, string subject, string htmlBody)
        {
            try
            {
                using (var client = new SmtpClient(_host, _port))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(_user, _pass);

                    using (var message = new MailMessage())
                    {
                        message.From = new MailAddress(_user, "e-Shift Support");
                        message.To.Add(new MailAddress(toEmail));
                        message.Subject = subject;
                        message.Body = htmlBody;
                        message.IsBodyHtml = true;

                        await client.SendMailAsync(message);
                    }
                }
            }
            catch (Exception ex)
            {
                // In a real application, you might log this error to a file
                MessageBox.Show($"Failed to send email. Please check your configuration and internet connection.\n\nError: {ex.Message}",
                                "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Creates a styled HTML email body.
        /// </summary>
        public string GetEmailHtmlTemplate(string title, string content, string customerName)
        {
            return $@"
            <!DOCTYPE html>
            <html>
            <head>
                <style>
                    body {{ font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif; margin: 0; padding: 0; background-color: #f4f4f4; }}
                    .container {{ max-width: 600px; margin: 20px auto; background-color: #ffffff; border-radius: 8px; overflow: hidden; box-shadow: 0 4px 15px rgba(0,0,0,0.1); }}
                    .header {{ background-color: #0D47A1; color: #ffffff; padding: 40px; text-align: center; }}
                    .header h1 {{ margin: 0; font-size: 28px; }}
                    .content {{ padding: 30px 40px; color: #555555; line-height: 1.6; }}
                    .content p {{ margin: 0 0 15px; }}
                    .footer {{ background-color: #f4f4f4; color: #888888; text-align: center; padding: 20px; font-size: 12px; }}
                </style>
            </head>
            <body>
                <div class='container'>
                    <div class='header'>
                        <h1>{title}</h1>
                    </div>
                    <div class='content'>
                        <p>Dear {customerName},</p>
                        {content}
                        <p>Thank you,<br/>The E-Shift Movers Team</p>
                    </div>
                    <div class='footer'>
                        <p>&copy; {DateTime.Now.Year} E-Shift Movers. All rights reserved.</p>
                        <p>No. 123, Thalpe, Galle, Sri Lanka</p>
                    </div>
                </div>
            </body>
            </html>";
        }
    }

}
