using GP_DigitalPropertyManegmentApi.Data.Context;

namespace DigitalPropertyManagmentApi.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<UserPropertyReview> UserPropertyReviews { get; set; }

    }
}
