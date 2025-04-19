using DigitalPropertyManagementBLL.Dtos;
using DigitalPropertyManagementBLL.Interfaces;
using GP_DigitalPropertyManegmentApi.Data.Context;
using GP_DigitalPropertyManegmentApi.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GP_DigitalPropertyManegmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServicesManager servicesManager;
        private readonly IConfiguration configuration;

        public PropertiesController(IUnitOfWork unitOfWork, IServicesManager servicesManager, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            this.servicesManager = servicesManager;
            this.configuration = configuration;
        }

        //[HttpGet("GetAll")]
        //public async Task<IActionResult> GetAllProperties([FromQuery] PropertyFilterDto filterDto)
        //{
        //    var properties = await _unitOfWork.Properties.GetAllAsync(filterDto);
        //    var propertiesRead = properties.Select(p => new PropertiesReadDto
        //    {
        //        PropertyId = p.PropertyId,
        //        Size = p.Size,
        //        Title = p.Title,
        //        Description = p.Description,
        //        PropertyType = p.PropertyType,
        //        Bedrooms = p.Bedrooms,
        //        Bathrooms = p.Bathrooms,
        //        Street = p.Street,
        //        City = p.City,
        //        Governate = p.Governate,
        //        PropertyImages = p.PropertyImages,
        //        ListedAt = p.ListedAt,
        //        Price = p.Price,
        //    });
        //    return Ok(propertiesRead);
        //}

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllProperty([FromQuery] PropertySpecificationsParameters specParams)
        {
            var properties = await servicesManager.PropertyServices.GetAllAsync(specParams);
            return Ok(properties);
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
        public async Task<IActionResult> GetPropertiesByType([FromRoute] string type)
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
        public async Task<IActionResult> GetPropertiesByCity([FromRoute] string city)
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
        public async Task<IActionResult> GetPropertiesByGovernerate([FromRoute] string governerate)
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

        [HttpPost("Create")]
        public async Task<IActionResult> CreateProperty([FromForm] PropertyCreateDto propertyDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newProperty = new Property
            {
                Size = propertyDto.Size,
                Title = propertyDto.Title,
                Description = propertyDto.Description,
                PropertyType = propertyDto.PropertyType,
                Bedrooms = propertyDto.Bedrooms,
                Bathrooms = propertyDto.Bathrooms,
                Street = propertyDto.Street,
                City = propertyDto.City,
                Governate = propertyDto.Governate,
                Price = propertyDto.Price,
                ListedAt = DateTime.UtcNow,

            };
            var imagesPath = DocumentSettings.UploadFiles(propertyDto.Images, "images");
            foreach (var image in imagesPath)
            {
                newProperty.PropertyImages.Add(new PropertyImage() 
                { ImageUrl = $"{configuration["BaseUrl"]}/files/images/{image}", PropertyId = newProperty.PropertyId });
            }

            await _unitOfWork.Properties.AddAsync(newProperty);
            await _unitOfWork.SaveAllAsync();

            return CreatedAtAction(nameof(GetPropertyById), new { id = newProperty.PropertyId }, newProperty);
        }

        [HttpPut("Update/{id:int}")]
        public async Task<IActionResult> UpdateProperty([FromRoute] int id, [FromBody] PropertyUpdateDto updateDto)
        {
            var existing = await _unitOfWork.Properties.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            existing.Size = updateDto.Size;
            existing.Title = updateDto.Title;
            existing.Description = updateDto.Description;
            existing.PropertyType = updateDto.PropertyType;
            existing.Bedrooms = updateDto.Bedrooms;
            existing.Bathrooms = updateDto.Bathrooms;
            existing.Street = updateDto.Street;
            existing.City = updateDto.City;
            existing.Governate = updateDto.Governate;
            existing.Price = updateDto.Price;

            _unitOfWork.Properties.Update(existing);
            await _unitOfWork.SaveAllAsync();

            return NoContent();
        }


        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> DeleteProperty([FromRoute] int id)
        {
            var existing = await _unitOfWork.Properties.GetByIdAsync(id);
            if (existing == null)
                return NotFound();
            List<string> images = new List<string>();
            foreach (var image in existing.PropertyImages)
            {
                images.Add(image.ImageUrl);
            }
            DocumentSettings.DeleteFiles(images);
            _unitOfWork.Properties.Delete(existing);
            await _unitOfWork.SaveAllAsync();

            return Ok($"Property with ID {id} was deleted.");
        }

    }
}
