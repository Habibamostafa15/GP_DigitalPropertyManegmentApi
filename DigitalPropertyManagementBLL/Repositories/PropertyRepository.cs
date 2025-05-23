﻿using DigitalPropertyManagementBLL.Dtos;
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

        public async Task AddAsync(Property property)
        {
            await _context.Properties.AddAsync(property);
        }

        public async Task<IEnumerable<Property>> GetAllAsync(PropertyFilterDto filter)
        {
            IQueryable<Property> query = _context.Properties;

            if (!string.IsNullOrWhiteSpace(filter.PropertyType))
            {
                query = query.Where(p => p.PropertyType.Trim().ToLower() == filter.PropertyType.Trim().ToLower());
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

        public async Task<Property?> GetByIdAsync(int id)
        {
            return await _context.Properties
           .Include(p => p.PropertyImages)
           .FirstOrDefaultAsync(p => p.PropertyId == id);
        }

        public async Task<Property> GetDetails(int id)
        {
            return await _context.Properties
                .Include(p=>p.PropertyImages)
                .Include(p=>p.UserPropertyReviews)
                .Include(p=>p.User)
                .Include(p=>p.ExternalAmenities)
                .Include(p=>p.InternalAmenities)
                .Include(p=>p.AccessibilityAmenities)
                .FirstOrDefaultAsync(p => p.PropertyId == id);
        }

        public async Task<IEnumerable<Property>> GetPropertiesByCityAsync(string city)
        {
            return await _context.Properties.Where(p => p.City.Trim().ToLower() == city.Trim().ToLower()).ToListAsync();
        }

        public async Task<IEnumerable<Property>> GetPropertiesByGovernorateAsync(string governorate)
        {
            return await _context.Properties.Where(p => p.Governate.Trim().ToLower() == governorate.Trim().ToLower()).ToListAsync();
        }

        public async Task<IEnumerable<Property>> GetPropertiesByTypeAsync(string propertyType)
        {
            return await _context.Properties.Where(p => p.PropertyType.Trim().ToLower() == propertyType.Trim().ToLower()).ToListAsync();
        }

        public void Update(Property property)
        {
            _context.Properties.Update(property);
        }

        public void Delete(Property property)
        {
            _context.Properties.Remove(property);
        }
    }
}
