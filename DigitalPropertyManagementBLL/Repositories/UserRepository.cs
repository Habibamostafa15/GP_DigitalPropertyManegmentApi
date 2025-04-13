using DigitalPropertyManagementBLL.Interfaces;
using GP_DigitalPropertyManegmentApi.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DigitalPropertyManagementBLL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
//*******************************************************************************
        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

//******************************************************************************************


        public async Task<bool> IsUserExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }
 //*************************************************************************************
        public async Task<bool> UpdateUserPasswordAsync(string email, string newPassword)
        {
            var user = await GetUserByEmailAsync(email);
            if (user != null)
            {
                user.PasswordHash = newPassword;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
  // *****************************************************************************************
    }
}
