

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
        public ICollection<ChatMessage> ChatMessages { get; set; }
        public ICollection<Preference> Preferences { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<SearchHistory> SearchHistories { get; set; }
        public ICollection<UserPropertyFavorite> UserPropertyFavorites { get; set; }
        public ICollection<UserPropertyReview> UserPropertyReviews { get; set; }
        public ICollection<UserPropertyPayment> UserPropertyPayments { get; set; }
        public ICollection<UserPropertyDocument> UserPropertyDocuments { get; set; }
    }
}
