namespace DigitalPropertyManagementBLL.Interfaces
{
    public interface IEmailService
    {
        Task SendOtpEmailAsync(string email, string otp);
    }
}
