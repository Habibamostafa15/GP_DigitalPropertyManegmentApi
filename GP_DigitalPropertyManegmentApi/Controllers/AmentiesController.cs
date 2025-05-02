using DigitalPropertyManagementBLL.Dtos;
using DigitalPropertyManagementBLL.Interfaces;
using DigitslPropertyManangementDAL.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GP_DigitalPropertyManegmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmentiesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public AmentiesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        [HttpGet("internal")]
        public async Task<IActionResult> GetAllInternalAmenities()
        {
            try
            {
                var amenities = await _unitOfWork.InternalAmenities.GetAllAsync();
                var result = amenities.Select(a => new AmenityReadDto { AmenityId = a.Id, Name = a.Name });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error fetching internal amenities: {ex.Message}");
            }
        }

        [HttpPost("internal")]
        public async Task<IActionResult> CreateInternalAmenity([FromBody] AmenityCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var amenity = new InternalAmenity { Name = dto.Name };
                await _unitOfWork.InternalAmenities.AddAsync(amenity);
                await _unitOfWork.SaveAllAsync();
                
                return Ok(amenity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating internal amenity: {ex.Message}");
            }
        }

        [HttpDelete("internal/{id}")]
        public async Task<IActionResult> DeleteInternalAmenity(int id)
        {
            try
            {
                var amenity = await _unitOfWork.InternalAmenities.GetByIdAsync(id);
                if (amenity == null)
                    return NotFound("Internal amenity not found.");

                _unitOfWork.InternalAmenities.Delete(amenity);
                await _unitOfWork.SaveAllAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting internal amenity: {ex.Message}");
            }
        }





        [HttpGet("external")]
        public async Task<IActionResult> GetAllExternalAmenities()
        {
            try
            {
                var amenities = await _unitOfWork.ExternalAmenities.GetAllAsync();
                var result = amenities.Select(a => new AmenityReadDto { AmenityId = a.Id, Name = a.Name });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error fetching external amenities: {ex.Message}");
            }
        }

        [HttpPost("external")]
        public async Task<IActionResult> CreateExternalAmenity([FromBody] AmenityCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var amenity = new ExternalAmenity { Name = dto.Name };
                await _unitOfWork.ExternalAmenities.AddAsync(amenity);
                await _unitOfWork.SaveAllAsync();
                return Ok(amenity);
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating external amenity: {ex.Message}");
            }
        }

        [HttpDelete("external/{id}")]
        public async Task<IActionResult> DeleteExternalAmenity(int id)
        {
            try
            {
                var amenity = await _unitOfWork.ExternalAmenities.GetByIdAsync(id);
                if (amenity == null)
                    return NotFound("External amenity not found.");

                _unitOfWork.ExternalAmenities.Delete(amenity);
                await _unitOfWork.SaveAllAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting external amenity: {ex.Message}");
            }
        }





        [HttpGet("accessibility")]
        public async Task<IActionResult> GetAllAccessibilityAmenities()
        {
            try
            {
                var amenities = await _unitOfWork.AccessibilityAmenities.GetAllAsync();
                var result = amenities.Select(a => new AmenityReadDto { AmenityId = a.Id, Name = a.Name });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error fetching accessibility amenities: {ex.Message}");
            }
        }

        [HttpPost("accessibility")]
        public async Task<IActionResult> CreateAccessibilityAmenity([FromBody] AmenityCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var amenity = new AccessibillityAmenity { Name = dto.Name };
                await _unitOfWork.AccessibilityAmenities.AddAsync(amenity);
                await _unitOfWork.SaveAllAsync();
                return Ok(amenity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating accessibility amenity: {ex.Message}");
            }
        }

        [HttpDelete("accessibility/{id}")]
        public async Task<IActionResult> DeleteAccessibilityAmenity(int id)
        {
            try
            {
                var amenity = await _unitOfWork.AccessibilityAmenities.GetByIdAsync(id);
                if (amenity == null)
                    return NotFound("Accessibility amenity not found.");

                _unitOfWork.AccessibilityAmenities.Delete(amenity);
                await _unitOfWork.SaveAllAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting accessibility amenity: {ex.Message}");
            }
        }

    }
}
