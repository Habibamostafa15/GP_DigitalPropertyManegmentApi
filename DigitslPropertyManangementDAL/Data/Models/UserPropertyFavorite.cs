

namespace GP_DigitalPropertyManegmentApi.Data.Context
{
    public class UserPropertyFavorite
    { 
        public int PropertyId { get; set; }        
        public int? UserId { get; set; }
        public int? FavoriteId { get; set; }
        public Favorite Favorite { get; set; }
        public User User { get; set; }
        public Property Property { get; set; }
    }
}
