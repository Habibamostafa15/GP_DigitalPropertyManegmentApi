
using DigitalPropertyManagmentApi.Models;
using System.ComponentModel.DataAnnotations;

namespace GP_DigitalPropertyManegmentApi.Data.Context
{
    public class UserPropertyReview
    {

        public int? PropertyId { get; set; }
        public Property Property { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public int? ReviewId { get; set; }
        public Review Review { get; set; }
    }

}
