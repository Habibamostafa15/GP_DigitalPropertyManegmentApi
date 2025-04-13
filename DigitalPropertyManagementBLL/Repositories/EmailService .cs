using DigitalPropertyManagementBLL.Interfaces;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace DigitalPropertyManagementBLL.Services
{
    public class EmailService : IEmailService
    {
        private readonly string _smtpServer = "smtp.gmail.com"; // خادم Gmail
        private readonly int _smtpPort = 587; // منفذ TLS
        private readonly string _smtpUser = "habiba.mostafa.567@gmail.com";
        private readonly string _smtpPass = "ysfrtlihzqojruey"; // استبدل بكلمة مرور التطبيق

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
                    Body = $"Your OTP for password reset is {otp}.",
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(email);

                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (SmtpException ex)
            {
                // تسجيل الخطأ لتسهيل التصحيح
                Console.WriteLine($"SMTP Error: {ex.Message}, Status: {ex.StatusCode}");
                throw new Exception("Failed to send OTP email.", ex);
            }
            catch (Exception ex)
            {
                // تسجيل أي أخطاء أخرى
                Console.WriteLine($"General Error: {ex.Message}");
                throw;
            }
        }
    }
}