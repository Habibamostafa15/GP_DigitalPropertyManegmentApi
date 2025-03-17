using DigitalPropertyManagementBLL.Interfaces;
using GP_DigitalPropertyManegmentApi.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalPropertyManagementBLL.Repositories
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly AppDbContext _context;
        public FavoriteRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddToFavoritesAsync(int propertyId, int userId)
        {
            var existingFavorite = await _context.UserPropertyFavorites
           .FirstOrDefaultAsync(f => f.UserId == userId && f.PropertyId == propertyId);
            if (existingFavorite != null)
            {
                return false;
            }

            var favorite = new UserPropertyFavorite
            {
                UserId = userId,
                PropertyId = propertyId

            };

            await _context.UserPropertyFavorites.AddAsync(favorite);
            return true;
        }

        public async Task<IEnumerable<Property>> GetFavoritePropertiesAsync(int userId)
        {
            return await _context.UserPropertyFavorites
                .Where(f=>f.UserId==userId)
                .Select(f=>f.Property)
                .ToListAsync();
        }
    }
}
