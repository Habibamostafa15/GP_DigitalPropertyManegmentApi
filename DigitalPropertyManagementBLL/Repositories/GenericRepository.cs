using DigitalPropertyManagementBLL.Interfaces;
using DigitalPropertyManagementBLL.Services;
using DigitslPropertyManangementDAL.Data.Models;
using GP_DigitalPropertyManegmentApi.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalPropertyManagementBLL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly AppDbContext context;
        public GenericRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity> spec)
        {
            return await context.Set<TEntity>().GetQuery(spec).ToListAsync();
        }
        public async Task<TEntity?> GetAsync(ISpecification<TEntity> spec)
        {
            return await context.Set<TEntity>().GetQuery(spec).FirstOrDefaultAsync();
        }
        public async Task Add(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
        }
        public void Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
        }
        public void Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }

        public async Task<int> CountAsync(ISpecification<TEntity> spec)
        {
            return await context.Set<TEntity>().CountAsync();
        }
    }
}
