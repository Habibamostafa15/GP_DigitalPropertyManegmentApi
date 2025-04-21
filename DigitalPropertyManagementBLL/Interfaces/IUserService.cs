using DigitalPropertyManagementBLL.Dtos;
using GP_DigitalPropertyManegmentApi.Data.Context;

namespace DigitalPropertyManagementBLL.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(UserDTO userDto);
        Task<bool> LoginAsync(LoginDTO loginDto);
        Task<User?> GetUserByEmailAsync(string email);
        Task<bool> ForgotPasswordAsync(string email);
        Task<bool> ResetPasswordAsync(string email, string newPassword, string confirmPassword);
        Task<string> GenerateOtpAsync(string email);
        Task<bool> VerifyOtpAsync(string email, string enteredOtp);
        Task<(bool Success, string Reason)> ResendOtpAsync(string email, string purpose);
        Task<(bool Success, string Reason)> ResendEmailConfirmationOtpAsync(string email);
        Task<User> LoginWithGoogleAsync(string email, string firstName, string lastName);
    }
}