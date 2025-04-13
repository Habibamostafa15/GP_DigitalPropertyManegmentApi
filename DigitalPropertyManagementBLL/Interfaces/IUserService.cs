using DigitalPropertyManagementBLL.Dtos;

namespace DigitalPropertyManagementBLL.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(UserDTO userDto);
        Task<bool> LoginAsync(LoginDTO loginDto);
        Task<bool> ForgotPasswordAsync(string email);
        Task<bool> ResetPasswordAsync(string email, string newPassword, string confirmPassword);
        Task<string> GenerateOtpAsync(string email);
        Task<bool> VerifyOtpAsync(string email, string enteredOtp);
        Task<bool> ResendOtpAsync(string email); 
    }
}
