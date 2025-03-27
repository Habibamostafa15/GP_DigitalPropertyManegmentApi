using DigitalPropertyManagementBLL.Interfaces;
using GP_DigitalPropertyManegmentApi.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalPropertyManagementBLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IPropertyRepository Properties { get; private set; }

        public IFavoriteRepository Favorites { get; private set; }

        public IReviewRepository Reviews { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Properties=new PropertyRepository(context);
            Favorites=new FavoriteRepository(context);
            Reviews = new ReviewRepository(context);
        }

        public async Task<int> SaveAllAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
