using DigitalPropertyManagementBLL.Interfaces;
using GP_DigitalPropertyManegmentApi.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DigitalPropertyManagementBLL.Repositories
{
    public class GenericAmenityRepository<TEntity> : IAmentiyRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;
        public GenericAmenityRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(TEntity entity)
        {
             await _context.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
             _context.Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
        }
    }
}
