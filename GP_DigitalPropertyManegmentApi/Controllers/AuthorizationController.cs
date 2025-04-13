using DigitalPropertyManagementBLL.Dtos;
using DigitalPropertyManagementBLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GP_DigitalPropertyManegmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<AuthorizationController> _logger;

        public AuthorizationController(IUserService userService, ILogger<AuthorizationController> logger)
        {
            _userService = userService;
            _logger = logger;
        }
// *********************************************************************************************************************************
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] UserDTO userDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest(new { Status = "Error", Message = "Invalid data provided.", Errors = errors });
            }

            if (!IsValidEmail(userDto.Email))
            {
                return BadRequest(new { Status = "Error", Message = "Please provide a valid email address." });
            }

            try
            {
                var result = await _userService.RegisterUserAsync(userDto);
                if (!result)
                {
                    _logger.LogWarning($"Registration failed for email: {userDto.Email}. Email might be taken, passwords might not match, or terms not accepted.");
                    return BadRequest(new { Status = "Error", Message = "Registration failed. Email might be taken, passwords might not match, or terms not accepted." });
                }

                return Ok(new { Status = "Success", Message = "User registered successfully." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while registering user with email: {userDto.Email}.");
                return StatusCode(500, new { Status = "Error", Message = "An unexpected error occurred. Please try again later." });
            }
        }

  // ****************************************************************************************************************************************
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest(new { Status = "Error", Message = "Invalid login data.", Errors = errors });
            }

            if (!IsValidEmail(loginDto.Email))
            {
                return BadRequest(new { Status = "Error", Message = "Please provide a valid email address." });
            }

            try
            {
                var result = await _userService.LoginAsync(loginDto);
                if (!result)
                {
                    _logger.LogWarning($"Login failed for email: {loginDto.Email}. Invalid email or password.");
                    return Unauthorized(new { Status = "Error", Message = "Invalid email or password." });
                }

                return Ok(new { Status = "Success", Message = "Login successful." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while logging in user with email: {loginDto.Email}.");
                return StatusCode(500, new { Status = "Error", Message = "An unexpected error occurred. Please try again later." });
            }
        }
 // *************************************************************************************************************************************
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] EmailDTO emailDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest(new { Status = "Error", Message = "Invalid email format.", Errors = errors });
            }

            if (!IsValidEmail(emailDto.Email))
            {
                return BadRequest(new { Status = "Error", Message = "Please provide a valid email address." });
            }

            try
            {
                var result = await _userService.ForgotPasswordAsync(emailDto.Email);
                if (!result)
                {
                    _logger.LogWarning($"Failed to send OTP to email: {emailDto.Email}. User not found or error occurred.");
                    return NotFound(new { Status = "Error", Message = "Email not found." });
                }

                return Ok(new { Status = "Success", Message = "OTP has been sent to your email." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while sending OTP to {emailDto.Email}.");
                return StatusCode(500, new { Status = "Error", Message = "An unexpected error occurred. Please try again later." });
            }
        }

 // ************************************************************************************************************************************************
        [HttpPost("resend-otp")]
        public async Task<IActionResult> ResendOtp([FromBody] EmailDTO emailDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest(new { Status = "Error", Message = "Invalid email format.", Errors = errors });
            }

            if (!IsValidEmail(emailDto.Email))
            {
                return BadRequest(new { Status = "Error", Message = "Please provide a valid email address." });
            }

            try
            {
                var result = await _userService.ResendOtpAsync(emailDto.Email);
                if (!result)
                {
                    _logger.LogWarning($"Failed to resend OTP to email: {emailDto.Email}. User not found, OTP still valid, or error occurred.");
                    return BadRequest(new { Status = "Error", Message = "Email not found or please wait before requesting a new OTP." });
                }

                return Ok(new { Status = "Success", Message = "A new OTP has been sent to your email." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while resending OTP to {emailDto.Email}.");
                return StatusCode(500, new { Status = "Error", Message = "An unexpected error occurred. Please try again later." });
            }
        }
  // ***************************************************************************************************************************************
        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp([FromBody] OTPDTO otpDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest(new { Status = "Error", Message = "Invalid OTP data.", Errors = errors });
            }

            if (!IsValidEmail(otpDto.Email))
            {
                return BadRequest(new { Status = "Error", Message = "Please provide a valid email address." });
            }

            if (string.IsNullOrWhiteSpace(otpDto.OTP) || otpDto.OTP.Length != 6 || !otpDto.OTP.All(char.IsDigit))
            {
                return BadRequest(new { Status = "Error", Message = "OTP must be a 6-digit number." });
            }

            try
            {
                var result = await _userService.VerifyOtpAsync(otpDto.Email, otpDto.OTP);
                if (!result)
                {
                    _logger.LogWarning($"Invalid OTP provided for email: {otpDto.Email}.");
                    return BadRequest(new { Status = "Error", Message = "Invalid or expired OTP." });
                }

                return Ok(new { Status = "Success", Message = "OTP verified successfully." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while verifying OTP for {otpDto.Email}.");
                return StatusCode(500, new { Status = "Error", Message = "An unexpected error occurred. Please try again later." });
            }
        }

// ******************************************************************************************************************************************************
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO resetPasswordDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest(new { Status = "Error", Message = "Invalid data provided.", Errors = errors });
            }

            if (!IsValidEmail(resetPasswordDto.Email))
            {
                return BadRequest(new { Status = "Error", Message = "Please provide a valid email address." });
            }

            if (resetPasswordDto.NewPassword != resetPasswordDto.ConfirmPassword)
            {
                return BadRequest(new { Status = "Error", Message = "Passwords do not match." });
            }

            if (string.IsNullOrWhiteSpace(resetPasswordDto.NewPassword) || resetPasswordDto.NewPassword.Length < 8)
            {
                return BadRequest(new { Status = "Error", Message = "Password must be at least 8 characters long." });
            }

            try
            {
                var result = await _userService.ResetPasswordAsync(resetPasswordDto.Email, resetPasswordDto.NewPassword, resetPasswordDto.ConfirmPassword);
                if (!result)
                {
                    _logger.LogWarning($"Failed to reset password for email: {resetPasswordDto.Email}.");
                    return BadRequest(new { Status = "Error", Message = "Failed to reset password. Ensure the email is correct." });
                }

                return Ok(new { Status = "Success", Message = "Password reset successfully." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while resetting password for {resetPasswordDto.Email}.");
                return StatusCode(500, new { Status = "Error", Message = "An unexpected error occurred. Please try again later." });
            }
        }
  // **********************************************************************************************************************************************
        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}
