using GP_DigitalPropertyManegmentApi.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalPropertyManagementBLL.Dtos
{
    public class PropertyFilterDto
    {
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }
        public string? PropertyType { get; set; }
        public int? Bedrooms { get; set; }
        public int? Bathrooms { get; set; }
        public string? SortBy { get; set; }
        public ICollection<Amenity>? Amenities { get; set; } = new List<Amenity>();
    }
}
