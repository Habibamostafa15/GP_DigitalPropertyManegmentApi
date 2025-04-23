using GP_DigitalPropertyManegmentApi.Data.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalPropertyManagementBLL.Dtos
{
    public class PropertiesReadDto
    {
        
        public int PropertyId { get; set; }      
        public string Title { get; set; }        
        public string Description { get; set; }        
        public double Price { get; set; }
        public string PropertyType { get; set; }
        public double Size { get; set; }        
        public int Bedrooms { get; set; }      
        public int Bathrooms { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Governate { get; set; }
        public DateTime ListedAt { get; set; } = DateTime.UtcNow;
        public ICollection<PropertyImage> PropertyImages { get; set; } = new List<PropertyImage>();

        public List<string> InternalAmenities { get; set; }
        public List<string> ExternalAmenities { get; set; }
        public List<string> AccessibilityAmenities { get; set; }
    }
}
