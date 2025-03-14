

using System.ComponentModel.DataAnnotations;

namespace GP_DigitalPropertyManegmentApi.Data.Context
{
    public class PropertyAmenity
    {
        [Key]
        public int AmenityId { get; set; }
        public Amenity Amenity { get; set; }
        public int? PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
