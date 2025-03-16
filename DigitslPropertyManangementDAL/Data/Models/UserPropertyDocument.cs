using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace GP_DigitalPropertyManegmentApi.Data.Context
{
    public class UserPropertyDocument
    {
        
        public int PropertyId { get; set; }
        public Property Property { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public int? DocumentId { get; set; }
        public Document Document { get; set; }

    }

}
