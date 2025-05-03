using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using DigitalPropertyManagementBLL.Dtos;
using DigitalPropertyManagementBLL.Interfaces;
using GP_DigitalPropertyManegmentApi.Helpers;

namespace GP_DigitalPropertyManegmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        // Existing UpdateUser endpoint
        [HttpPut("Update")]
        [Authorize]
        public async Task<IActionResult> UpdateUser([FromForm] UserUpdateDto userDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized();

            var ImagePath = DocumentSettings.UploadFile(userDto.Image, "UserImage");

            userDto.ImageUrl = $"{_configuration["BaseUrl"]}/files/UserImage/{ImagePath}";

            int id = int.Parse(userId.Value);
            var flag = await _userService.UpdateUser(id, userDto);

            var userResponse = new UserResponseDto
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
                City = userDto.City,
                ImageUrl = userDto.ImageUrl,
            };

            return flag ? Ok(userResponse) : BadRequest();
        }

        // Existing GetUser endpoint
        [HttpGet("GetUser")]
        [Authorize]
        public async Task<IActionResult> GetUser()
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier);
            if (user == null) return Unauthorized();
            var userId = int.Parse(user.Value);

            var result = await _userService.GetUserByIdAsync(userId);
            if (result == null) return NotFound();

            var userDto = new UserResponseDto
            {
                FirstName = result.FirstName,
                LastName = result.LastName,
                Email = result.Email,
                PhoneNumber = result.PhoneNumber,
                City = result.City,
                ImageUrl = result.ImageUrl,
            };

            return Ok(userDto);
        }

        // New ChangePassword endpoint
        [HttpPut("ChangePassword")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized(new { message = "User not authenticated." });
            }

            int userId = int.Parse(userIdClaim.Value);
            var result = await _userService.ChangePasswordAsync(userId, changePasswordDto);

            if (!result)
            {
                return BadRequest(new { message = "Failed to change password. Please check your input and try again." });
            }

            return Ok(new { message = "Password changed successfully." });
        }
    }
}