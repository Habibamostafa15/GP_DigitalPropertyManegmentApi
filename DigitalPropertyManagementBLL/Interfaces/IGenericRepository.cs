using DigitslPropertyManangementDAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalPropertyManagementBLL.Interfaces
{
    public interface IGenericRepository<TEntity>
        where TEntity : BaseEntity
    {
        Task<int> CountAsync(ISpecification<TEntity> spec);
        Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity> spec);
        Task<TEntity?> GetAsync(ISpecification<TEntity> spec);
        Task Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
