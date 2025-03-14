
namespace GP_DigitalPropertyManegmentApi.Data.Context
{
    public class Preference
    {
        public int PreferenceId { get; set; }
        public string PreferenceType { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
