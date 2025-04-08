using System.Net.Mail;
using System.Net;

namespace CourseManager.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmail(string toEmail, string subject, string body)
        {
            var smtpSettings = _configuration.GetSection("Smtp");

            using (var client = new SmtpClient(smtpSettings["Host"], int.Parse(smtpSettings["Port"])))
            {
                client.Credentials = new NetworkCredential(smtpSettings["Username"], smtpSettings["Password"]);
                client.EnableSsl = bool.Parse(smtpSettings["EnableSsl"]);

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(smtpSettings["Username"]),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };
                mailMessage.To.Add(toEmail);

                // Send email synchronously
                client.Send(mailMessage);
            }
        }
    }
}
