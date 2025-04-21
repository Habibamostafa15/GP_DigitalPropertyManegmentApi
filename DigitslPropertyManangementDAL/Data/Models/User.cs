namespace GP_DigitalPropertyManegmentApi.Data.Context
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? City { get; set; }
        public string? BirthOfDate { get; set; }
        public string? PasswordHash { get; set; }
        public string? GoogleId { get; set; }
        public bool IsTermsAccepted { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; } = "pending"; // إضافة حقل Status مع قيمة افتراضية

        // Navigational Properties
        public int? NotificationId { get; set; }
        public Notification? Notification { get; set; }
        public ICollection<ChatMessage> ChatMessages { get; set; } = new List<ChatMessage>();
        public ICollection<Preference> Preferences { get; set; } = new List<Preference>();
        public ICollection<SearchHistory> SearchHistories { get; set; } = new List<SearchHistory>();
        public ICollection<UserPropertyReview> UserPropertyReviews { get; set; }
        public ICollection<UserPropertyFavorite> UserPropertyFavorites { get; set; }
        public ICollection<UserPropertyPayment> UserPropertyPayments { get; set; }
        public ICollection<UserPropertyDocument> UserPropertyDocuments { get; set; }
    }
}