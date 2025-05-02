using DigitalPropertyManagementBLL.Interfaces;
using DigitslPropertyManangementDAL.Data.Models;
using GP_DigitalPropertyManegmentApi.Data.Context;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace DigitalPropertyManagementBLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IPropertyRepository Properties { get; private set; }
        public IFavoriteRepository Favorites { get; private set; }
        public IReviewRepository Reviews { get; private set; }
        public IUserRepository Users { get; private set; }
        public IInternalAmenityRepository InternalAmenities { get; private set; }
        public IExternalAmenityRepository ExternalAmenities { get; private set; }
        public IAccessibilityAmenityRepository AccessibilityAmenities { get; private set; }

        //***********************************************************************************
        private readonly ConcurrentDictionary<string, object> _repositoty;
      //***********************************************************************************
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Properties = new PropertyRepository(context);
            Favorites = new FavoriteRepository(context);
            Reviews = new ReviewRepository(context);
            Users = new UserRepository(context);
            InternalAmenities=new InternalAmenityRepository(context);
            ExternalAmenities=new ExternalAmenityRepository(context);
            AccessibilityAmenities=new AccessibilityAmenityRepository(context);
            _repositoty = new ConcurrentDictionary<string, object>();
        }

        //*****************************************************************************
        public IGenericRepository<TEntity> GetRepository<TEntity>()
            where TEntity : BaseEntity
        {
            return (IGenericRepository<TEntity>) _repositoty.GetOrAdd(typeof(TEntity).Name, new GenericRepository<TEntity>(_context));
        }


        public async Task<int> SaveAllAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
