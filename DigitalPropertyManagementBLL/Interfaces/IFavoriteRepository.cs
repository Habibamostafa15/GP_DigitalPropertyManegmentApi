using DigitalPropertyManagementBLL.Dtos;
using GP_DigitalPropertyManegmentApi.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalPropertyManagementBLL.Interfaces
{
    public interface IFavoriteRepository
    {
        Task<bool> AddToFavoritesAsync(int propertyId, int userId);
        Task<IEnumerable<PropertyFavoriteDto>> GetFavoritePropertiesAsync(int userId);
        Task<bool> RemoveFromFavoritesAsync(int userId, int propertyId);
        Task<bool> IsFavoriteAsync(int userId, int propertyId);
    }
}
