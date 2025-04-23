using DigitalPropertyManagementBLL.Dtos;
using GP_DigitalPropertyManegmentApi.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalPropertyManagementBLL.Services.Specifications
{
    public class PropertyWithIncludedsSpecification : BaseSpecification<Property>
    {
        public PropertyWithIncludedsSpecification() : base(null)
        {
            ApplyIncludes();
        }
        public PropertyWithIncludedsSpecification(PropertySpecificationsParameters specParams)
            : base
            (
                 p =>
                    (string.IsNullOrEmpty(specParams.PropertyType) || p.PropertyType.ToLower().Contains(specParams.PropertyType.ToLower())) &&
                    (string.IsNullOrEmpty(specParams.City) || p.City.ToLower().Contains(specParams.City.ToLower())) &&
                    (string.IsNullOrEmpty(specParams.Governate) || p.City.ToLower().Contains(specParams.Governate.ToLower())) &&
                    (!specParams.Size.HasValue || p.Size == specParams.Size) &&
                    (!specParams.MaxPrice.HasValue || p.Price <= specParams.MaxPrice) &&
                    (!specParams.MinPrice.HasValue || p.Price >= specParams.MinPrice) &&
                    (!specParams.Bedrooms.HasValue || p.Bedrooms == specParams.Bedrooms) &&
                    (!specParams.Bathrooms.HasValue || p.Bathrooms == specParams.Bathrooms) &&
                    (
                        specParams.InternalAmenityIds == null || 
                        specParams.InternalAmenityIds.All(id => p.InternalAmenities.Any(a => a.Id == id))
                    ) &&
                    (
                        specParams.ExternalAmenityIds == null || 
                        specParams.ExternalAmenityIds.All(id => p.ExternalAmenities.Any(a => a.Id == id))
                    ) &&
                    (
                        specParams.AccessibilityAmenityIds == null ||
                        specParams.AccessibilityAmenityIds.All(id => p.AccessibilityAmenities.Any(a => a.Id == id))
                    )
            )
        {
            ApplyIncludes();
            ApplySort(specParams.SortBy);
            ApplyPagination(specParams.PageIndex, specParams.PageSize);
        }

        public PropertyWithIncludedsSpecification(string city)
            : base
            (
                  p => p.City.Trim().ToLower() == city.Trim().ToLower()
            )
        {
            ApplyIncludes();
        }
        private void ApplySort(string? sort)
        {
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort.ToLower())
                {
                    case "price":
                        AddOrderBy(p => p.Price);
                        break;
                    case "pricedesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    case "oldest":
                        AddOrderBy(p => p.ListedAt);
                        break;
                    default: //newest
                        AddOrderByDescending(p => p.ListedAt);
                        break;
                }
            }
            else
            {
                AddOrderByDescending(p => p.ListedAt);
            }
        }
        private void ApplyIncludes()
        {
            AddInclude(p => p.PropertyImages);
            AddInclude(p => p.User);
            //AddInclude(p => p.Amenities);
            AddInclude(p => p.InternalAmenities);
            AddInclude(p => p.ExternalAmenities);
            AddInclude(p => p.AccessibilityAmenities);
        }
    }
}
