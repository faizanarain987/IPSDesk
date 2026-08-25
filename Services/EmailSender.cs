using System.Net;
using System.Net.Mail;
using IPSDesk.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace IPSDesk.Services
{
    public class EmailSender : IEmailSender<ApplicationUser>
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink)
        {
            var subject = "Confirm your email";
            var body = $"Please confirm your account by <a href='{confirmationLink}'>clicking here</a>.";
            await SendEmailAsync(email, subject, body);
        }

        public async Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink)
        {
            var subject = "Reset your password";
            var body = $"Please reset your password by <a href='{resetLink}'>clicking here</a>.";
            await SendEmailAsync(email, subject, body);
        }

        public async Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode)
        {
            var subject = "Reset your password";
            var body = $"Please reset your password using the following code: {resetCode}";
            await SendEmailAsync(email, subject, body);
        }

        private async Task SendEmailAsync(string toEmail, string subject, string htmlBody)
        {
            var smtpServer = _configuration["SmtpSettings:Server"];
            var smtpPortVal = _configuration["SmtpSettings:Port"];
            var senderEmail = _configuration["SmtpSettings:SenderEmail"];
            var senderName = _configuration["SmtpSettings:SenderName"];
            var username = _configuration["SmtpSettings:Username"];
            var password = _configuration["SmtpSettings:Password"];
            var enableSslVal = _configuration["SmtpSettings:EnableSsl"];

            // If SMTP server is not configured, fall back to writing to debug/console
            if (string.IsNullOrEmpty(smtpServer) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                System.Diagnostics.Debug.WriteLine($"[EMAIL MOCK] To: {toEmail}, Subject: {subject}, Body: {htmlBody}");
                return;
            }

            int port = int.TryParse(smtpPortVal, out var p) ? p : 587;
            bool enableSsl = !bool.TryParse(enableSslVal, out var ssl) || ssl; // default to true

            using var client = new SmtpClient(smtpServer, port)
            {
                Credentials = new NetworkCredential(username, password),
                EnableSsl = enableSsl
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(senderEmail ?? username, senderName ?? "Diamond ISP Support"),
                Subject = subject,
                Body = htmlBody,
                IsBodyHtml = true
            };
            mailMessage.To.Add(toEmail);

            await client.SendMailAsync(mailMessage);
        }
    }
}
