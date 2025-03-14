using System.ComponentModel.DataAnnotations;

namespace GP_DigitalPropertyManegmentApi.Data.Context
{
    public class PropertyImage
    {
        [Key]
        public int ImageId { get; set; }
        public string ImageUrl { get; set; }
        public DateTime UploadedAt { get; set; }
        public int? PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
