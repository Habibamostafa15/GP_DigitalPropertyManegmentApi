using GP_DigitalPropertyManegmentApi.Data.Context;

namespace DigitalPropertyManagementBLL.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(string email);
        Task<User?> GetUserByIdAsync(int id);

        Task AddUserAsync(User user);

        Task<bool> IsUserExistsAsync(string email);

        Task<bool> UpdateUserPasswordAsync(string email, string newPassword);

        void UpdateUser(User user);
    }
}
