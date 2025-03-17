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
        Task<IEnumerable<Property>> GetFavoritePropertiesAsync(int userId);
    }
}
