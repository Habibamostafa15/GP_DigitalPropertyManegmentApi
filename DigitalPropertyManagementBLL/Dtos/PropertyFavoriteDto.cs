using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalPropertyManagementBLL.Dtos
{
    public class PropertyFavoriteDto
    {
        public int PropertyId { get; set; }
        public string Title { get; set; }
        public string MainImageUrl { get; set; } // First image only
        public string City { get; set; }
        public string Governate { get; set; }
        public double Price { get; set; }
        public string ListingType { get; set; }
        public DateTime AddedToFavoritesAt { get; set; }
    }
}
