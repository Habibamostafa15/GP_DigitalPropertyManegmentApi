using DigitalPropertyManagementBLL.Dtos;
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

            var addToFavorites = new Favorite
            {
                AddedAt = DateTime.Now,
            };

            await _context.Favorites.AddAsync(addToFavorites);

            var favorite = new UserPropertyFavorite
            {
                UserId = userId,
                PropertyId = propertyId,
                FavoriteId = addToFavorites.FavoriteId
            };

            await _context.UserPropertyFavorites.AddAsync(favorite);
            return true;
        }

        public async Task<IEnumerable<PropertyFavoriteDto>> GetFavoritePropertiesAsync(int userId)
        {
            var favoriteProperties = await _context.UserPropertyFavorites
                .Where(f => f.UserId == userId)
                .Include(f => f.Property)
                    .ThenInclude(p => p.PropertyImages)
                .Select(f => f.Property)
                .ToListAsync();

            var favoritePropertyDtos = await _context.UserPropertyFavorites
                .Where(f => f.UserId == userId)
                .Include(f => f.Property)
                    .ThenInclude(p => p.PropertyImages)
                .Include(f => f.Favorite)
                .Select(f => new PropertyFavoriteDto
                {
                    PropertyId = f.Property.PropertyId,
                    Title = f.Property.Title,
                    Description = f.Property.Description,
                    Price = f.Property.Price,
                    PropertyType = f.Property.PropertyType,
                    Size = f.Property.Size,
                    Bedrooms = f.Property.Bedrooms,
                    Bathrooms = f.Property.Bathrooms,
                    Street = f.Property.Street,
                    City = f.Property.City,
                    Governate = f.Property.Governate,
                    ListedAt = f.Property.ListedAt,
                    PropertyImages = f.Property.PropertyImages,
                    AddedToFavoritesAt = f.Favorite.AddedAt
                })
                .ToListAsync();


            return favoritePropertyDtos;
        }



        public async Task<bool> IsFavoriteAsync(int userId, int propertyId)
        { 
           
            return await _context.UserPropertyFavorites.AnyAsync(f => f.UserId == userId && f.PropertyId == propertyId);
        }



        public async Task<bool> RemoveFromFavoritesAsync(int userId, int propertyId)
        {
            var favorite = await _context.UserPropertyFavorites
                .FirstOrDefaultAsync(f => f.UserId == userId && f.PropertyId == propertyId);

            if (favorite == null)
            {
                return false;
            }

            if (favorite.FavoriteId.HasValue)
            {
                var favoriteRecord = await _context.Favorites.FirstOrDefaultAsync(f => f.FavoriteId == favorite.FavoriteId.Value);

                if (favoriteRecord != null)
                {
                    _context.Favorites.Remove(favoriteRecord);
                }
            }

            _context.UserPropertyFavorites.Remove(favorite);

            return true;
        }

    }
}
