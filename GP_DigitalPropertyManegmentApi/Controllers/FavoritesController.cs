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

        [HttpGet("favorites/{userId}")]
        public async Task<IActionResult> GetFavoriteProperties(int userId)
        {
            var properties = await _unitOfWork.Favorites.GetFavoritePropertiesAsync(userId);
            return Ok(properties);

        }
    }
}
