using DigitalPropertyManagementBLL.Dtos;
using DigitalPropertyManagementBLL.Interfaces;
using GP_DigitalPropertyManegmentApi.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalPropertyManagementBLL.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {

        private readonly AppDbContext _context;

        public PropertyRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Property>> GetAllAsync(PropertyFilterDto filter)
        {
            IQueryable<Property> query = _context.Properties;

            if (!string.IsNullOrWhiteSpace(filter.PropertyType))
            {
                query = query.Where(p => p.PropertyType == filter.PropertyType);
            }

            if (filter.MaxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= filter.MaxPrice);
            }

            if (filter.MinPrice.HasValue)
            {
                query = query.Where(p => p.Price >= filter.MinPrice);
            }

            if (filter.Bedrooms.HasValue)
            {
                query = query.Where(p => p.Bedrooms == filter.Bedrooms);
            }

            if (filter.Bathrooms.HasValue)
            {
                query = query.Where(p => p.Bathrooms == filter.Bathrooms);
            }

            //if (filter.Amenities != null && filter.Amenities.Any())
            //{
            //    query = query.Where(p => p.Amenities.Any(pa => !string.IsNullOrEmpty(pa.Name) && filter.Amenities.Contains(pa.Name)));
            //}

            query = filter.SortBy switch
            {
                "price_asc" => query.OrderBy(p => p.Price),
                "price_desc" => query.OrderByDescending(p => p.Price),
                "newest" => query.OrderByDescending(p => p.ListedAt),
                "oldest" => query.OrderBy(p => p.ListedAt),
                _ => query.OrderByDescending(p => p.ListedAt) // Default sorting
            };

            return await query.ToListAsync();
        }

        public async Task<Property> GetDetails(int id)
        {
            return await _context.Properties
                .Include(p=>p.PropertyImages)
                .Include(p=>p.Amenities)
                .Include(p=>p.UserPropertyReviews)
                .FirstOrDefaultAsync(p => p.PropertyId == id);
        }

        public async Task<IEnumerable<Property>> GetPropertiesByCityAsync(string city)
        {
            return await _context.Properties.Where(p => p.City == city).ToListAsync();
        }

        public async Task<IEnumerable<Property>> GetPropertiesByGovernorateAsync(string governorate)
        {
            return await _context.Properties.Where(p => p.Governate == governorate).ToListAsync();
        }

        public async Task<IEnumerable<Property>> GetPropertiesByTypeAsync(string propertyType)
        {
            return await _context.Properties.Where(p => p.PropertyType == propertyType).ToListAsync();
        }
    }
}
