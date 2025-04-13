namespace GP_DigitalPropertyManegmentApi.Data.Context
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; } // Nullable لأن Google مش بيوفّرها دايمًا
        public string? City { get; set; }       // Nullable لنفس السبب
        public string? BirthOfDate { get; set; } // Nullable لأنها مش مضمونة من Google
        public string? PasswordHash { get; set; } // Nullable لأن Google Auth مش بيحتاج كلمة سر
        public string? GoogleId { get; set; }   // حقل جديد لتخزين معرف Google
        public bool IsTermsAccepted { get; set; }
        public DateTime CreatedAt { get; set; }

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