using DigitalPropertyManagementBLL.Dtos;
using DigitalPropertyManagementBLL.Interfaces;
using DigitalPropertyManagmentApi.Models;
using GP_DigitalPropertyManegmentApi.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalPropertyManagementBLL.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDbContext _context;
        public ReviewRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddReviewAsync(int userId, int propertyId, CreateReviewDto createReviewDto)
        {
            var review= await _context.UserPropertyReviews
                .FirstOrDefaultAsync(r => r.UserId == userId && r.PropertyId == propertyId);

            if (review != null)
            {
                return false;
            }

            var newReview = new Review()
            {
                Rating = createReviewDto.Rating,
                Comment = createReviewDto.Comment,
                CreatedAt=DateTime.UtcNow
            };

            await _context.Reviews.AddAsync(newReview);

            var userPropertyReview = new UserPropertyReview()
            {
                UserId = userId,
                PropertyId = propertyId,
                ReviewId = newReview.ReviewId,
            };

            await _context.UserPropertyReviews.AddAsync(userPropertyReview);
            return true;

        }

        //public async Task<IEnumerable<ReviewReadDto>> GetReviewsForPropertyAsync(int propertyId)
        //{
        //    var propertyReviews = _context.UserPropertyReviews
        //        .Where(r => r.PropertyId == propertyId)
        //        .Select(r => new ReviewReadDto
        //        {
                  
        //            Rating = r.Review.Rating,
        //            Comment = r.Review.Comment,
        //            CreatedAt = r.Review.CreatedAt
        //        })
        //        .ToListAsync();

        //    return await propertyReviews;
        //}

        public async Task<bool> RemoveReviewAsync(int userId, int propertyId)
        {
            var existingReview = await _context.UserPropertyReviews
                .FirstOrDefaultAsync(r => r.UserId == userId && r.PropertyId == propertyId);
            if (existingReview == null)
            {
                return false;
            }
            _context.UserPropertyReviews .Remove(existingReview);
            _context.Reviews.Remove(existingReview.Review);
            return true;
        }

        public async Task<bool> UpdateReviewAsync(int userId, int propertyId, UpdateReviewDto updateReviewDto)
        {
            var existingReview = await _context.UserPropertyReviews
                .FirstOrDefaultAsync(r => r.UserId == userId && r.PropertyId == propertyId);

            if (existingReview == null)
            {
                return false; 
            }

    
            existingReview.Review.Rating = updateReviewDto.Rating;
            existingReview.Review.Comment = updateReviewDto.Comment;

            return true;
        }
    }
}
