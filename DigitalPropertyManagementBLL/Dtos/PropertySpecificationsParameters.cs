using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalPropertyManagementBLL.Dtos
{
    public class PropertySpecificationsParameters
    {
        public string? PropertyType { get; set; }
        public string? City { get; set; }
        public string? Governate { get; set; }

        public int? Bedrooms { get; set; }
        public int? Bathrooms { get; set; }
        public string? SortBy { get; set; }
        public double? Size { get; set; }

        public double? MaxPrice { get; set; }
        public double? MinPrice { get; set; }


        public List<int>? InternalAmenityIds { get; set; }
        public List<int>? ExternalAmenityIds { get; set; }
        public List<int>? AccessibilityAmenityIds { get; set; }


        private int pageIndex = 1;
        private int pageSize = 5;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }
        public int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }
    }
}
