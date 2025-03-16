using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GP_DigitalPropertyManegmentApi.Data.Context
{
    public class Favorite
    {
        public int FavoriteId { get; set; }
        public DateTime AddedAt { get; set; } = DateTime.UtcNow;

        public ICollection<UserPropertyFavorite> UserPropertyFavorites { get; set; }

    }
}
