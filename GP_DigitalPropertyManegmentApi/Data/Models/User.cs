

namespace GP_DigitalPropertyManegmentApi.Data.Context
{
    public class User
    {

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        //Navigational Properties
        // OneToMany With Notification
        public int? NotificationId { get; set; }
        public Notification Notification { get; set; }

        // OneToMany With ChatMessage
        public ICollection<ChatMessage> ChatMessages { get; set; } = new List<ChatMessage>();

        // OneToMany With Preference
        public ICollection<Preference> Preferences { get; set; } = new List<Preference>();

        // OneToMany With SearchHistory
        public ICollection<SearchHistory> SearchHistories { get; set; } = new List<SearchHistory>();

        // ManyToMany
        public ICollection<UserPropertyReview> UserPropertyReviews { get; set; }
        public ICollection<UserPropertyFavorite> UserPropertyFavorites { get; set; }

        public ICollection<UserPropertyPayment> UserPropertyPayments { get; set; }
        public ICollection<UserPropertyDocument> UserPropertyDocuments { get; set; }
    }
}
