using DigitalPropertyManagementBLL.Dtos;
using GP_DigitalPropertyManegmentApi.Data.Context;
using System.Threading.Tasks;

namespace DigitalPropertyManagementBLL.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(UserDTO userDto);
        Task<bool> LoginAsync(LoginDTO loginDto);
        Task<UserResultDto> Login(LoginDTO loginDto);
        Task<User?> GetUserByEmailAsync(string email);
        Task<User?> GetUserByIdAsync(int id);
        Task<string> GenerateOtpAsync(string email);
        Task<(bool Success, string Message)> VerifyOtpAsync(string email, string enteredOtp);
        Task<bool> ResetPasswordAsync(string email, string newPassword, string confirmPassword);
        Task<(bool Success, string Message)> ForgotPasswordAsync(string email);
        Task<(bool Success, string Reason)> ResendOtpAsync(string email, string purpose);
        Task<(bool Success, string Reason)> ResendEmailConfirmationOtpAsync(string email);
        Task<User> LoginWithGoogleAsync(string email, string firstName, string lastName);

        Task<bool> UpdateUser(int id, UserUpdateDto userDto);
        Task<bool> ChangePasswordAsync(int userId, ChangePasswordDto changePasswordDto);
    }
}