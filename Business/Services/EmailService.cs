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
    }
}
