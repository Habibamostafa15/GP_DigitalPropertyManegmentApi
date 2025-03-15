

using System.ComponentModel.DataAnnotations;

namespace GP_DigitalPropertyManegmentApi.Data.Context
{
    public class ChatMessage
    {
        [Key]
        public int MessageId { get; set; }
        public string UserQuestion { get; set; }
        public string BotResponse { get; set; }
        public DateTime TimeStamp { get; set; }
        // OneToMany With User
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
