using DigitalPropertyManagementBLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalPropertyManagementBLL.Interfaces
{
    public interface IReviewRepository
    {
        public Task<bool> AddReviewAsync(int userId, int propertyId, CreateReviewDto createReviewDto);
        //public Task<IEnumerable<ReviewReadDto>> GetReviewsForPropertyAsync(int propertyId);
        public Task<bool> UpdateReviewAsync(int userId, int propertyId, UpdateReviewDto updateReviewDto);
        public Task<bool> RemoveReviewAsync(int userId, int propertyId);
    }
}
