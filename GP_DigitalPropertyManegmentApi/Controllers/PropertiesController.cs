using DigitalPropertyManagementBLL.Dtos;
using DigitalPropertyManagementBLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GP_DigitalPropertyManegmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public PropertiesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllProperties([FromQuery] PropertyFilterDto filterDto)
        {
            var properties = await _unitOfWork.Properties.GetAllAsync(filterDto);
            var propertiesRead = properties.Select(p => new PropertiesReadDto
            {
                PropertyId = p.PropertyId,
                Size = p.Size,
                Title = p.Title,
                Description = p.Description,
                PropertyType = p.PropertyType,
                Bedrooms = p.Bedrooms,
                Bathrooms = p.Bathrooms,
                Street = p.Street,
                City = p.City,
                Governate = p.Governate,
                PropertyImages = p.PropertyImages,
                ListedAt = p.ListedAt,
                Price = p.Price,
            });
            return Ok(propertiesRead);
        }


        [HttpGet("GetById/{id:int}")]
        public async Task<IActionResult> GetPropertyById([FromRoute] int id)
        {
            var property = await _unitOfWork.Properties.GetDetails(id);
            if (property == null)
            {
                return NotFound("Invalid Id!");
            }
            return Ok(property);
        }


        [HttpGet("GetByType/{type:alpha}")]
        public async Task<IActionResult> GetPropertiesByType([FromRoute]string type)
        {
            var properties = await _unitOfWork.Properties.GetPropertiesByTypeAsync(type);
            var propertiesRead = properties.Select(p => new PropertiesReadDto
            {
                PropertyId = p.PropertyId,
                Size = p.Size,
                Title = p.Title,
                Description = p.Description,
                PropertyType = p.PropertyType,
                Bedrooms = p.Bedrooms,
                Bathrooms = p.Bathrooms,
                Street = p.Street,
                City = p.City,
                Governate = p.Governate,
                PropertyImages = p.PropertyImages,
                ListedAt = p.ListedAt,
                Price = p.Price,
            });
            return Ok(propertiesRead);
        }

        [HttpGet("GetByCity/{city:alpha}")]
        public async Task<IActionResult> GetPropertiesByCity([FromRoute]string city)
        {
            var properties = await _unitOfWork.Properties.GetPropertiesByCityAsync(city);
            var propertiesRead = properties.Select(p => new PropertiesReadDto
            {
                PropertyId = p.PropertyId,
                Size = p.Size,
                Title = p.Title,
                Description = p.Description,
                PropertyType = p.PropertyType,
                Bedrooms = p.Bedrooms,
                Bathrooms = p.Bathrooms,
                Street = p.Street,
                City = p.City,
                Governate = p.Governate,
                PropertyImages = p.PropertyImages,
                ListedAt = p.ListedAt,
                Price = p.Price,
            });
            return Ok(propertiesRead);
        }

        [HttpGet("GetByGovernerate/{governerate:alpha}")]
        public async Task<IActionResult> GetPropertiesByGovernerate([FromRoute]string governerate)
        {
            var properties = await _unitOfWork.Properties.GetPropertiesByCityAsync(governerate);
            var propertiesRead = properties.Select(p => new PropertiesReadDto
            {
                PropertyId = p.PropertyId,
                Size = p.Size,
                Title = p.Title,
                Description = p.Description,
                PropertyType = p.PropertyType,
                Bedrooms = p.Bedrooms,
                Bathrooms = p.Bathrooms,
                Street = p.Street,
                City = p.City,
                Governate = p.Governate,
                PropertyImages = p.PropertyImages,
                ListedAt = p.ListedAt,
                Price = p.Price,
            });
            return Ok(propertiesRead);
        }
    }
}
