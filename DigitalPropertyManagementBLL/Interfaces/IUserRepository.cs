using GP_DigitalPropertyManegmentApi.Data.Context;

namespace DigitalPropertyManagementBLL.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(string email);

        Task AddUserAsync(User user);

        Task<bool> IsUserExistsAsync(string email);

        Task<bool> UpdateUserPasswordAsync(string email, string newPassword);
    }
}
