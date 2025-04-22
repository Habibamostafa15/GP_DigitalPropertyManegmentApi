using DigitalPropertyManagementBLL.Dtos;
using GP_DigitalPropertyManegmentApi.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalPropertyManagementBLL.Services.Specifications
{
    public class PropertyWithCountSpecification : BaseSpecification<Property>
    {
        public PropertyWithCountSpecification(PropertySpecificationsParameters specParams)
           : base
            (
              p =>
                  (string.IsNullOrEmpty(specParams.PropertyType) || p.PropertyType.ToLower().Contains(specParams.PropertyType.ToLower())) &&
                  (!specParams.Bedrooms.HasValue || p.Bedrooms == specParams.Bedrooms) &&
                  (!specParams.Bathrooms.HasValue || p.Bathrooms == specParams.Bathrooms)
            )
        {

        }

        public PropertyWithCountSpecification(string city)
           : base
            (
              p => p.City.Trim().ToLower() == city.Trim().ToLower()
            )
        {

        }

    }
}
