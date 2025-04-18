﻿using DigitalPropertyManagementBLL.Dtos;
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
        public PropertyWithIncludedsSpecification() :base(null)
        {
            ApplyIncludes();
        }
        public PropertyWithIncludedsSpecification(PropertySpecificationsParameters specParams)
            : base
            (
                  p =>
                  (string.IsNullOrEmpty(specParams.PropertyType) || p.PropertyType.ToLower().Contains(specParams.PropertyType.ToLower())) &&
                  (!specParams.Bedrooms.HasValue || p.Bedrooms == specParams.Bedrooms) &&
                  (!specParams.Bathrooms.HasValue || p.Bathrooms == specParams.Bathrooms)
            )
        {
            ApplyIncludes();
            ApplySort(specParams.SortBy);
            ApplyPagination(specParams.PageIndex,specParams.PageSize);
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
            //AddInclude(p => p.Amenities);
            AddInclude(p => p.PropertyImages);
        }
    }
}
