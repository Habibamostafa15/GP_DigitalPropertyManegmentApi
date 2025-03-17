using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalPropertyManagementBLL.Interfaces
{
    public interface IUnitOfWork
    {
        IPropertyRepository Properties { get; }
        IFavoriteRepository Favorites { get; }
        Task<int> SaveAllAsync();
    }
}
