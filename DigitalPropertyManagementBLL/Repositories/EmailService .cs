using DigitalPropertyManagementBLL.Interfaces;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace DigitalPropertyManagementBLL.Services
{
    public class EmailService : IEmailService
    {
        private readonly string _smtpServer = "smtp.gmail.com";
        private readonly int _smtpPort = 587;
        private readonly string _smtpUser = "habiba.mostafa.567@gmail.com";
        private readonly string _smtpPass = "ysfrtlihzqojruey";

        public async Task SendOtpEmailAsync(string email, string otp)
        {
            try
            {
                using var smtpClient = new SmtpClient(_smtpServer)
                {
                    Port = _smtpPort,
                    Credentials = new NetworkCredential(_smtpUser, _smtpPass),
                    EnableSsl = true,
                };

                using var mailMessage = new MailMessage
                {
                    From = new MailAddress(_smtpUser),
                    Subject = "Password Reset OTP",
                    Body = $"<h2>Password Reset Request</h2>" +
                           $"<p>We received a request to reset your password. Your One-Time Password (OTP) is:</p>" +
                           $"<h3>{otp}</h3>" +
                           $"<p>This OTP will expire in 5 minutes. Please enter it to reset your password.</p>" +
                           $"<p>If you did not request this, please ignore this email.</p>",
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(email);

                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine($"SMTP Error: {ex.Message}, Status: {ex.StatusCode}");
                throw new Exception("Failed to send OTP email.", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}");
                throw;
            }
        }

        public async Task SendEmailConfirmationOtpAsync(string email, string otp)
        {
            try
            {
                using var smtpClient = new SmtpClient(_smtpServer)
                {
                    Port = _smtpPort,
                    Credentials = new NetworkCredential(_smtpUser, _smtpPass),
                    EnableSsl = true,
                };

                using var mailMessage = new MailMessage
                {
                    From = new MailAddress(_smtpUser),
                    Subject = "Verify Your Email Address",
                    Body = $"<h2>Welcome to Digital Property Management!</h2>" +
                           $"<p>Thank you for signing up. Your One-Time Password (OTP) to verify your email address is:</p>" +
                           $"<h3>{otp}</h3>" +
                           $"<p>This OTP will expire in 5 minutes. Please enter it to complete your registration.</p>" +
                           $"<p>If you did not request this, please ignore this email.</p>",
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(email);

                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine($"SMTP Error: {ex.Message}, Status: {ex.StatusCode}");
                throw new Exception("Failed to send email confirmation OTP.", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}");
                throw;
            }
        }
    }
}