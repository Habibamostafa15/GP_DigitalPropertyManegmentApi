using DigitalPropertyManagementBLL.Dtos;
using DigitalPropertyManagementBLL.Interfaces;
using GP_DigitalPropertyManegmentApi.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GP_DigitalPropertyManegmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReviewsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        //[HttpGet("{propertyId}")]
        //public async Task<IActionResult> GetReviewsForProperty([FromRoute] int propertyId)
        //{
        //    var propertyReviews = await _unitOfWork.Reviews.GetReviewsForPropertyAsync(propertyId);
        //    return Ok(propertyReviews);
        //}


        [HttpPost("{userId}/{propertyId}")]
        public async Task<IActionResult> AddReview([FromRoute]int userId,[FromRoute]int propertyId,[FromBody] CreateReviewDto reviewDto)
        {
            var result = await _unitOfWork.Reviews.AddReviewAsync(userId, propertyId, reviewDto);
            if(!result)
            {
                return BadRequest("Review could not be added!");
            }
            await _unitOfWork.SaveAllAsync();
            return Ok("The review is added successfully");
        }


        [HttpPut("{userId}/{reviewId}")]
        public async Task<IActionResult> UpdateReview([FromRoute]int userId, [FromRoute]int reviewId, [FromBody] UpdateReviewDto reviewDto)
        {
            var result = await _unitOfWork.Reviews.UpdateReviewAsync(userId,reviewId, reviewDto);
            if (!result)
            {
                return BadRequest("Review update failed!");
            }
               
            await _unitOfWork.SaveAllAsync();
            return Ok("Review updated successfully.");
        }


        [HttpDelete("{userId}/{reviewId}")]
        public async Task<IActionResult> DeleteReview([FromRoute] int userId, [FromRoute]int reviewId)
        {
            var result = await _unitOfWork.Reviews.RemoveReviewAsync(userId,reviewId);
            if (!result)
                return NotFound("Review not found or delete failed.");

            await _unitOfWork.SaveAllAsync();
            return Ok("Review deleted successfully.");
        }
    }
}
