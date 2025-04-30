using DigitalPropertyManagementBLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [HttpPost("{propertyId:int}")]
        public async Task<IActionResult> AddToFavorites([FromRoute] int propertyId)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrWhiteSpace(userIdClaim))
            {
                return Unauthorized("User ID not found in claims.");
            }

            if (!int.TryParse(userIdClaim, out var userId))
            {
                return Unauthorized("Invalid user ID.");
            }
                
            var success = await _unitOfWork.Favorites.AddToFavoritesAsync(propertyId, userId);
            if (!success)
            {
                return BadRequest("Could not add to favorites.");
            }
            return Ok("Property added to favorites.");
        }

        [HttpGet()]
        public async Task<IActionResult> GetFavoriteProperties()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrWhiteSpace(userIdClaim))
            {
                return Unauthorized("User ID not found in claims.");
            }

            if (!int.TryParse(userIdClaim, out var userId))
            {
                return Unauthorized("Invalid user ID.");
            }
            var properties = await _unitOfWork.Favorites.GetFavoritePropertiesAsync(userId);
            return Ok(properties);

        }

        [HttpGet("added/{propertyId}")]
        public async Task<IActionResult> IsFavorite([FromRoute] int propertyId)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrWhiteSpace(userIdClaim))
            {
                return Unauthorized("User ID not found in claims.");
            }

            if (!int.TryParse(userIdClaim, out var userId))
            {
                return Unauthorized("Invalid user ID.");
            }
            var isFav = await _unitOfWork.Favorites.IsFavoriteAsync(userId, propertyId);
            return Ok(isFav);
        }

        [HttpDelete("remove/{propertyId}")]
        public async Task<IActionResult> RemoveFromFavorites(int propertyId)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrWhiteSpace(userIdClaim))
            {
                return Unauthorized("User ID not found in claims.");
            }

            if (!int.TryParse(userIdClaim, out var userId))
            {
                return Unauthorized("Invalid user ID.");
            }
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
