
namespace GP_DigitalPropertyManegmentApi.Data.Context
{
    public class SearchHistory
    {
        public int Id { get; set; }
        public string SearchQuery { get; set; }

        // OneToMany With User
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
