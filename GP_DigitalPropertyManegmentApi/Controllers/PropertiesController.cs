using AutoMapper;
using DigitalPropertyManagementBLL.Dtos;
using DigitalPropertyManagementBLL.Interfaces;
using DigitalPropertyManagementBLL.Services;
using GP_DigitalPropertyManegmentApi.Data.Context;
using GP_DigitalPropertyManegmentApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GP_DigitalPropertyManegmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServicesManager _servicesManager;
        private readonly IUserService _userService;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public PropertiesController(IUnitOfWork unitOfWork, IServicesManager servicesManager, IUserService userService, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _servicesManager = servicesManager;
            _userService = userService;
            this.mapper = mapper;
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
            var properties = await _servicesManager.PropertyServices.GetAllAsync(specParams);
            return Ok(properties);
        }

        #region Recommend without PaginationResponse
        //[HttpGet("Recommend")]
        //public async Task<IActionResult> RecommendProperties()
        //{
        //    var email = User.FindFirst(ClaimTypes.Email)?.Value;

        //    if (string.IsNullOrWhiteSpace(email))
        //        return Unauthorized("Email not found in user claims.");

        //    var user = await _userService.GetUserByEmailAsync(email);

        //    if (user == null)
        //        return NotFound("User not found.");

        //    if (string.IsNullOrWhiteSpace(user.City))
        //        return BadRequest("User does not have a city set in their profile.");

        //    var properties = await _unitOfWork.Properties.GetPropertiesByCityAsync(user.City);

        //    var recommended = properties.Select(p => new PropertiesReadDto
        //    {
        //        PropertyId = p.PropertyId,
        //        Title = p.Title,
        //        Description = p.Description,
        //        Price = p.Price,
        //        Size = p.Size,
        //        Street = p.Street,
        //        City = p.City,
        //        Governate = p.Governate,
        //        PropertyType = p.PropertyType,
        //        Bedrooms = p.Bedrooms,
        //        Bathrooms = p.Bathrooms,
        //        ListedAt = p.ListedAt,
        //        PropertyImages = p.PropertyImages
        //    });

        //    return Ok(recommended);
        //} 
        #endregion

        [HttpGet("Recommend")]
        public async Task<IActionResult> RecommendProperties(int pageIndex = 1, int pageSize = 5)
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;

            if (string.IsNullOrWhiteSpace(email)) 
                return Unauthorized("Email not found in user claims.");

            var user = await _userService.GetUserByEmailAsync(email);

            if (user == null) return NotFound("User not found.");

            if (string.IsNullOrWhiteSpace(user.City))
                return BadRequest("User does not have a city set in their profile.");
            var recommended = await _servicesManager.PropertyServices.GetPropertiesByCityAsync(user.City, pageIndex, pageSize);

            return Ok(recommended);
        }

        [HttpGet("GetById/{id:int}")]
        public async Task<IActionResult> GetPropertyById([FromRoute] int id)
        {
            var property = await _unitOfWork.Properties.GetDetails(id);
            if (property == null)
            {
                return NotFound("Invalid Id!");
            }

            PropertyDetailsDto propertyDto = new PropertyDetailsDto
            {
                PropertyId = property.PropertyId,
                Title = property.Title,
                Description = property.Description,
                Price = property.Price,
                Bedrooms = property.Bedrooms,
                Bathrooms = property.Bathrooms,
                PropertyType = property.PropertyType,
                ListedAt = property.ListedAt,
                LocationUrl=property.LocationUrl,
                ListingType=property.ListingType,

                ImageUrls = property.PropertyImages?.Select(img => img.ImageUrl).ToList(),
                ExternalAmenities = property.ExternalAmenities?.Select(a=>a.Name).ToList(),
                InternalAmenities = property.InternalAmenities?.Select(a=>a.Name).ToList(),
                AccessibilityAmenities = property.AccessibilityAmenities?.Select(a=>a.Name).ToList(),
                Reviews = property.UserPropertyReviews?.Select(r => new ReviewReadDto
                {
                    ReviewerName = r.User?.FirstName + " " + r.User?.LastName,
                    Comment = r.Review.Comment,
                    Rating = r.Review.Rating,
                    CreatedAt = r.Review.CreatedAt
                }).ToList(),

                OwnerInfo = new OwnerInfoDto
                {
                    FirstName = property.User.FirstName,
                    LastName = property.User.LastName,
                    Email = property.User.Email,
                    PhoneNumber = property.User.PhoneNumber
                }
            };

            return Ok(propertyDto);
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
                UserId=propertyDto.UserId,
                LocationUrl = propertyDto.LocationUrl,
                ListingType = propertyDto.ListingType,
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
            existing.UserId=updateDto.UserId;
            existing.LocationUrl=updateDto.LocationUrl;
            existing.ListingType=updateDto.ListingType;

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
