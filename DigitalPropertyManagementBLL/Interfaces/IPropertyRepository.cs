using DigitalPropertyManagementBLL.Dtos;
using GP_DigitalPropertyManegmentApi.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalPropertyManagementBLL.Interfaces
{
    public interface IPropertyRepository
    {
        Task<IEnumerable<Property>> GetAllAsync(PropertyFilterDto filter);
        Task<Property> GetDetails(int id);
        Task AddAsync(Property property);
        Task<Property?> GetByIdAsync(int id);
        void Update(Property property);
        void Delete(Property property);
        Task<IEnumerable<Property>> GetPropertiesByGovernorateAsync(string governorate);
        Task<IEnumerable<Property>> GetPropertiesByCityAsync(string city);
        Task<IEnumerable<Property>> GetPropertiesByTypeAsync(string propertyType);

    }
}
