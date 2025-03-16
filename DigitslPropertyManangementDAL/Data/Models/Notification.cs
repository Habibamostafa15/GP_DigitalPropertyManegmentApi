

namespace GP_DigitalPropertyManegmentApi.Data.Context
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime SentAt { get; set; }

        // OneToMany With User
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}

