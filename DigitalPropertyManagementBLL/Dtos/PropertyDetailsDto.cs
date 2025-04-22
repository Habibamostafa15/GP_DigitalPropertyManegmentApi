using DigitslPropertyManangementDAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalPropertyManagementBLL.Dtos
{
    public class PropertyDetailsDto
    {
        public int PropertyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string LocationUrl { get; set; }
        public string ListingType { get; set; }
        public double Price { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public string PropertyType { get; set; }
        public DateTime ListedAt { get; set; }

        public List<string> ImageUrls { get; set; }
        public List<ReviewReadDto>? Reviews { get; set; }
        public OwnerInfoDto OwnerInfo { get; set; }
        public List<string> ExternalAmenities { get; set; }
        public List<string> InternalAmenities { get; set; }
        public List<string> AccessibilityAmenities { get; set; }
    }
}
