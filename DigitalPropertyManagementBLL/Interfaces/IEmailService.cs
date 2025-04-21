namespace DigitalPropertyManagementBLL.Interfaces
{
    public interface IEmailService
    {
        Task SendOtpEmailAsync(string email, string otp); 
        Task SendEmailConfirmationOtpAsync(string email, string otp);
    }
}