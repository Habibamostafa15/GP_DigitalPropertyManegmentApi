using DigitalPropertyManagementBLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GP_DigitalPropertyManegmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public FavoritesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("{userId}/favorite/{propertyId}")]
        public async Task<IActionResult> AddToFavorites([FromRoute] int propertyId, [FromRoute] int userId)
        {
            var success = await _unitOfWork.Favorites.AddToFavoritesAsync(propertyId, userId);
            if (!success)
            {
                return BadRequest("Could not add to favorites.");
            }
            return Ok("Property added to favorites.");
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetFavoriteProperties([FromRoute]int userId)
        {
            var properties = await _unitOfWork.Favorites.GetFavoritePropertiesAsync(userId);
            return Ok(properties);

        }

        [HttpGet("{userId}/added/{propertyId}")]
        public async Task<IActionResult> IsFavorite([FromRoute] int userId, [FromRoute] int propertyId)
        {
            var isFav = await _unitOfWork.Favorites.IsFavoriteAsync(userId, propertyId);
            return Ok(isFav);
        }

        [HttpDelete("{userId}/remove/{propertyId}")]
        public async Task<IActionResult> RemoveFromFavorites(int userId, int propertyId)
        {
            var success = await _unitOfWork.Favorites.RemoveFromFavoritesAsync(userId, propertyId);
            if (!success)
            {
                return NotFound("Favorite not found.");
            }
                
            await _unitOfWork.SaveAllAsync();
            return Ok("Property removed from favorites.");
        }
    }
    
}
