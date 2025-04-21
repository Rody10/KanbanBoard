using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace KanbanBoard.Services
{
    public class EmailSender : IEmailSender
    {
  
        private readonly IConfiguration? configuration;

        public EmailSender(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage) // email is the recepient's email address
        {
            var originEmail = configuration.GetValue<string>("EMAIL_CONFIGURATION:EMAIL");
            var password = configuration.GetValue<string>("EMAIL_CONFIGURATION:PASSWORD");
            var host = configuration.GetValue<string>("EMAIL_CONFIGURATION:HOST");
            var port = configuration.GetValue<int>("EMAIL_CONFIGURATION:PORT");

            

            var smtpClient = new SmtpClient(host, port);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;

            smtpClient.Credentials = new NetworkCredential(originEmail, password);

            var message = new MailMessage(originEmail, email, subject, htmlMessage);

            Console.WriteLine($"email: {email}");
            Console.WriteLine($"subject: {subject}");
            Console.WriteLine($"htmlMessage: {htmlMessage}");
            Console.WriteLine($"originEmail: {originEmail}");
            Console.WriteLine($"email: {email}");
            Console.WriteLine($"password: {password}");
            Console.WriteLine($"host: {host}");
            Console.WriteLine($"port: {port}");

            await smtpClient.SendMailAsync(message);
        }

    }
}
