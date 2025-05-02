using DigitslPropertyManangementDAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalPropertyManagementBLL.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IPropertyRepository Properties { get; }
        IFavoriteRepository Favorites { get; }
        IReviewRepository Reviews { get; }
        IUserRepository Users { get; }
        IInternalAmenityRepository InternalAmenities { get; }
        IExternalAmenityRepository ExternalAmenities { get; }
        IAccessibilityAmenityRepository AccessibilityAmenities { get; }
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
        Task<int> SaveAllAsync();
    }
}
