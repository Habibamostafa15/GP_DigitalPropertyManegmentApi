using System.ComponentModel.DataAnnotations;

namespace GP_DigitalPropertyManegmentApi.Data.Context

{
    public class Amenity
    {
        public int AmenityId { get; set; }
        [Required]
        public string Name { get; set; }

       public virtual ICollection<Property> Properties { get; set; } = new List<Property>();

    }
}      
