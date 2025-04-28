using DigitalPropertyManagementBLL.Dtos;
using DigitalPropertyManagementBLL.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GP_DigitalPropertyManegmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(IUserService userService, ILogger<AuthenticationController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

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

                _logger.LogInformation($"User with email {userDto.Email} registered successfully. Awaiting email verification.");
                return Ok(new { Status = "Success", Message = "Registration successful. Please check your email to verify your account with the OTP." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while registering user with email: {userDto.Email}.");
                return StatusCode(500, new { Status = "Error", Message = "An unexpected error occurred while registering the user. Please try again later." });
            }
        }

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
                var user = await _userService.GetUserByEmailAsync(loginDto.Email.ToLower());
                if (user == null)
                {
                    _logger.LogWarning($"Login failed for email: {loginDto.Email}. User not found.");
                    return Unauthorized(new { Status = "Error", Message = "Invalid email or password. Please check your credentials and try again." });
                }

                if (user.Status != "active")
                {
                    _logger.LogWarning($"Login failed for email: {loginDto.Email}. Account not verified.");
                    return Unauthorized(new { Status = "Error", Message = "Your account is not verified. Please verify your email with the OTP sent to you." });
                }

                var userResult = await _userService.Login(loginDto);
                if (userResult is null) throw new Exception();
                
                return Ok(userResult);
                //var result = await _userService.LoginAsync(loginDto);
                //if (!result)
                //{
                //    _logger.LogWarning($"Login failed for email: {loginDto.Email}. Invalid email or password.");
                //    return Unauthorized(new { Status = "Error", Message = "Invalid email or password. Please check your credentials and try again." });
                //}

                //var claims = new List<Claim>
                //{
                //    new Claim(ClaimTypes.Email, user.Email),
                //    new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}")
                //};
                //var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                //var principal = new ClaimsPrincipal(identity);

                //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                //_logger.LogInformation($"User with email {loginDto.Email} logged in successfully.");
                //return Ok(new { Status = "Success", Message = "Login successful." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while logging in user with email: {loginDto.Email}.");
                return StatusCode(500, new { Status = "Error", Message = "An unexpected error occurred while logging in. Please try again later." });
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            _logger.LogInformation("User logged out successfully.");
            return Ok(new { Status = "Success", Message = "Logout successful." });
        }

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
                var (success, message) = await _userService.ForgotPasswordAsync(emailDto.Email);
                if (!success)
                {
                    _logger.LogWarning($"Failed to send OTP to email: {emailDto.Email}. Reason: {message}");
                    return NotFound(new { Status = "Error", Message = message });
                }

                _logger.LogInformation($"OTP sent to email: {emailDto.Email} for password reset.");
                return Ok(new { Status = "Success", Message = message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while sending OTP to {emailDto.Email}.");
                return StatusCode(500, new { Status = "Error", Message = "An unexpected error occurred while sending the OTP. Please try again later." });
            }
        }

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
                var user = await _userService.GetUserByEmailAsync(emailDto.Email.ToLower());
                if (user == null)
                {
                    _logger.LogWarning($"Failed to resend OTP to email: {emailDto.Email}. User not found.");
                    return NotFound(new { Status = "Error", Message = "Email not found. Please ensure the email is registered." });
                }

                var (success, reason) = await _userService.ResendOtpAsync(emailDto.Email, "passwordreset");
                if (!success)
                {
                    _logger.LogWarning($"Failed to resend OTP to email: {emailDto.Email}. Reason: {reason}");
                    return BadRequest(new { Status = "Error", Message = reason });
                }

                _logger.LogInformation($"New OTP sent to email: {emailDto.Email} for password reset.");
                return Ok(new { Status = "Success", Message = reason });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while resending OTP to {emailDto.Email}.");
                return StatusCode(500, new { Status = "Error", Message = "An unexpected error occurred while resending the OTP. Please try again later." });
            }
        }

        [HttpPost("resend-email-confirmation-otp")]
        public async Task<IActionResult> ResendEmailConfirmationOtp([FromBody] EmailDTO emailDto)
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
                var user = await _userService.GetUserByEmailAsync(emailDto.Email.ToLower());
                if (user == null)
                {
                    _logger.LogWarning($"Failed to resend email confirmation OTP to email: {emailDto.Email}. User not found.");
                    return NotFound(new { Status = "Error", Message = "Email not found. Please ensure the email is registered." });
                }

                var (success, reason) = await _userService.ResendEmailConfirmationOtpAsync(emailDto.Email);
                if (!success)
                {
                    _logger.LogWarning($"Failed to resend email confirmation OTP to email: {emailDto.Email}. Reason: {reason}");
                    return BadRequest(new { Status = "Error", Message = reason });
                }

                _logger.LogInformation($"New email confirmation OTP sent to email: {emailDto.Email}.");
                return Ok(new { Status = "Success", Message = reason });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while resending email confirmation OTP to {emailDto.Email}.");
                return StatusCode(500, new { Status = "Error", Message = "An unexpected error occurred while resending the email confirmation OTP. Please try again later." });
            }
        }

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
                var (success, message) = await _userService.VerifyOtpAsync(otpDto.Email, otpDto.OTP);
                if (!success)
                {
                    _logger.LogWarning($"Invalid OTP provided for email: {otpDto.Email}.");
                    return BadRequest(new { Status = "Error", Message = message });
                }

                _logger.LogInformation($"OTP verified successfully for email: {otpDto.Email}.");
                return Ok(new { Status = "Success", Message = message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while verifying OTP for {otpDto.Email}.");
                return StatusCode(500, new { Status = "Error", Message = "An unexpected error occurred while verifying the OTP. Please try again later." });
            }
        }

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
                    _logger.LogWarning($"Failed to reset password for email: {resetPasswordDto.Email}. OTP might not be verified for password reset.");
                    return BadRequest(new { Status = "Error", Message = "Failed to reset password. Please request an OTP for password reset and verify it first." });
                }

                _logger.LogInformation($"Password reset successfully for email: {resetPasswordDto.Email}.");
                return Ok(new { Status = "Success", Message = "Password reset successfully." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while resetting password for {resetPasswordDto.Email}.");
                return StatusCode(500, new { Status = "Error", Message = "An unexpected error occurred while resetting the password. Please try again later." });
            }
        }

        [HttpGet("login-google")]
        public async Task<IActionResult> LoginGoogle(string returnUrl = "/")
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if (!string.IsNullOrEmpty(returnUrl) && !Uri.IsWellFormedUriString(returnUrl, UriKind.Relative))
            {
                return BadRequest(new { Status = "Error", Message = "Invalid return URL." });
            }

            var properties = new AuthenticationProperties
            {
                RedirectUri = Url.Action(nameof(GoogleResponse), "Authorization", new { returnUrl }, Request.Scheme),
                Items = { { "returnUrl", returnUrl } }
            };

            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [HttpGet("google-response")]
        public async Task<IActionResult> GoogleResponse(string returnUrl = "/")
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (!result.Succeeded)
            {
                _logger.LogWarning("Google authentication failed.");
                return Unauthorized(new { Status = "Error", Message = "Google authentication failed." });
            }

            var email = result.Principal.FindFirst(ClaimTypes.Email)?.Value;
            var firstName = result.Principal.FindFirst(ClaimTypes.GivenName)?.Value;
            var lastName = result.Principal.FindFirst(ClaimTypes.Surname)?.Value;

            if (string.IsNullOrEmpty(email))
            {
                _logger.LogWarning("Unable to retrieve email from Google.");
                return BadRequest(new { Status = "Error", Message = "Unable to retrieve email from Google." });
            }

            var user = await _userService.LoginWithGoogleAsync(email, firstName, lastName);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}")
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            _logger.LogInformation($"User with email {email} logged in successfully using Google.");
            return LocalRedirect(returnUrl);
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}