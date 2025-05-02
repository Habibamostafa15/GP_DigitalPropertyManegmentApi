using AutoMapper;
using DigitalPropertyManagementBLL.Dtos;
using DigitalPropertyManagementBLL.Interfaces;
using GP_DigitalPropertyManegmentApi.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Management;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DigitalPropertyManagementBLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
        private readonly IPasswordHasher<User> _passwordHasher;
        private static readonly Dictionary<string, (string Otp, DateTime Expiry, DateTime LastRequestTime, string Purpose)> _otpStore = new();

        public UserService(IUserRepository userRepository, IEmailService emailService, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _emailService = emailService;
            _passwordHasher = passwordHasher;
        }

        public async Task<bool> RegisterUserAsync(UserDTO userDto)
        {
            if (userDto.Password != userDto.ConfirmPassword)
            {
                return false;
            }

            var existingUser = await _userRepository.GetUserByEmailAsync(userDto.Email.ToLower());
            if (existingUser != null)
            {
                return false;
            }

            if (!userDto.IsTermsAccepted)
            {
                return false;
            }

            var user = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email.ToLower(),
                PhoneNumber = userDto.PhoneNumber,
                City = userDto.City,
                BirthOfDate = userDto.BirthOfDate,
                IsTermsAccepted = userDto.IsTermsAccepted,
                PasswordHash = _passwordHasher.HashPassword(null, userDto.Password),
                CreatedAt = DateTime.UtcNow,
                Status = "pending"
            };

            await _userRepository.AddUserAsync(user);

            var otp = await GenerateOtpAsync(userDto.Email);
            if (string.IsNullOrEmpty(otp))
            {
                return false;
            }

            await StoreOtpAsync(userDto.Email, otp, "signup");

            try
            {
                await _emailService.SendEmailConfirmationOtpAsync(userDto.Email, otp);
                Console.WriteLine($"OTP {otp} sent to email: {userDto.Email} for email verification.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send OTP email: {ex.Message}");
                return false;
            }

            return true;
        }

        public async Task<bool> LoginAsync(LoginDTO loginDto)
        {
            var user = await _userRepository.GetUserByEmailAsync(loginDto.Email.ToLower());
            if (user == null)
            {
                return false;
            }

            if (user.Status != "active")
            {
                return false;
            }

            var result = _passwordHasher.VerifyHashedPassword(null, user.PasswordHash, loginDto.Password);
            if (result != PasswordVerificationResult.Success)
            {
                return false;
            }

            return true;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email.ToLower());
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            var result = await _userRepository.GetUserByIdAsync(id);
            return result;
        }

        public async Task<string> GenerateOtpAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email.ToLower());
            if (user == null)
            {
                return string.Empty;
            }

            var otp = new Random().Next(100000, 999999).ToString();
            return otp;
        }

        public async Task<(bool Success, string Message)> VerifyOtpAsync(string email, string enteredOtp)
        {
            var storedOtpData = await GetStoredOtpAsync(email);

            if (storedOtpData == null || storedOtpData?.Otp == null)
            {
                Console.WriteLine("No OTP found for this email or OTP expired.");
                return (false, "Invalid or expired OTP.");
            }

            bool isValid = storedOtpData.Value.Otp == enteredOtp;

            if (isValid)
            {
                var user = await _userRepository.GetUserByEmailAsync(email.ToLower());
                if (user != null && storedOtpData.Value.Purpose == "signup")
                {
                    user.Status = "active";
                    await _userRepository.UpdateUserPasswordAsync(email, user.PasswordHash);
                    await ClearStoredOtpAsync(email);
                    return (true, "Account activated successfully.");
                }
                else if (storedOtpData.Value.Purpose == "passwordreset")
                {
                    return (true, "OTP verified successfully. You can now reset your password.");
                }
            }

            Console.WriteLine($"Stored OTP: {storedOtpData?.Otp}, Entered OTP: {enteredOtp}");
            return (false, "Invalid OTP.");
        }

        public async Task<bool> ResetPasswordAsync(string email, string newPassword, string confirmPassword)
        {
            var storedOtpData = await GetStoredOtpAsync(email);
            if (storedOtpData == null || storedOtpData?.Purpose != "passwordreset")
            {
                return false;
            }

            if (newPassword != confirmPassword)
            {
                return false;
            }

            var user = await _userRepository.GetUserByEmailAsync(email.ToLower());
            if (user == null)
            {
                return false;
            }

            var hashedPassword = _passwordHasher.HashPassword(null, newPassword);
            await _userRepository.UpdateUserPasswordAsync(email, hashedPassword);
            await ClearStoredOtpAsync(email);
            return true;
        }

        public async Task<(bool Success, string Message)> ForgotPasswordAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email.ToLower());
            if (user == null)
            {
                return (false, "Email not found.");
            }

            var otp = await GenerateOtpAsync(email);
            if (string.IsNullOrEmpty(otp))
            {
                return (false, "Failed to generate OTP.");
            }

            await StoreOtpAsync(email, otp, "passwordreset");

            try
            {
                await _emailService.SendOtpEmailAsync(email, otp);
                Console.WriteLine($"OTP {otp} sent to email: {email}.");
                return (true, "OTP sent successfully for password reset.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send OTP email: {ex.Message}");
                return (false, "Failed to send OTP email.");
            }
        }

        public async Task<(bool Success, string Reason)> ResendOtpAsync(string email, string purpose)
        {
            var user = await _userRepository.GetUserByEmailAsync(email.ToLower());
            if (user == null)
            {
                return (false, "Email not found. Please ensure the email is registered.");
            }

            if (purpose != "passwordreset")
            {
                return (false, "This endpoint is only for password reset OTPs. Use the appropriate endpoint for email confirmation.");
            }

            if (_otpStore.TryGetValue(email, out var otpData))
            {
                var timeSinceLastRequest = DateTime.UtcNow - otpData.LastRequestTime;
                if (timeSinceLastRequest.TotalSeconds < 60)
                {
                    return (false, $"Please wait {60 - timeSinceLastRequest.TotalSeconds} seconds before requesting a new OTP.");
                }

                if (otpData.Expiry > DateTime.UtcNow)
                {
                    return (false, "An OTP is already valid. Please wait until it expires.");
                }
            }

            var otp = await GenerateOtpAsync(email);
            if (string.IsNullOrEmpty(otp))
            {
                return (false, "Failed to generate OTP.");
            }

            await StoreOtpAsync(email, otp, "passwordreset");

            try
            {
                await _emailService.SendOtpEmailAsync(email, otp);
                Console.WriteLine($"OTP {otp} sent to email: {email} for password reset.");
                return (true, "OTP resent successfully for password reset.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to resend OTP email: {ex.Message}");
                return (false, "Failed to resend OTP email.");
            }
        }

        public async Task<(bool Success, string Reason)> ResendEmailConfirmationOtpAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email.ToLower());
            if (user == null)
            {
                return (false, "Email not found. Please ensure the email is registered.");
            }

            if (user.Status != "pending")
            {
                return (false, "This email is already verified or not in a pending state.");
            }

            if (_otpStore.TryGetValue(email, out var otpData))
            {
                var timeSinceLastRequest = DateTime.UtcNow - otpData.LastRequestTime;
                if (timeSinceLastRequest.TotalSeconds < 60)
                {
                    return (false, $"Please wait {60 - timeSinceLastRequest.TotalSeconds} seconds before requesting a new OTP.");
                }

                if (otpData.Expiry > DateTime.UtcNow)
                {
                    return (false, "An OTP is already valid. Please wait until it expires.");
                }
            }

            var otp = await GenerateOtpAsync(email);
            if (string.IsNullOrEmpty(otp))
            {
                return (false, "Failed to generate OTP.");
            }

            await StoreOtpAsync(email, otp, "signup");

            try
            {
                await _emailService.SendEmailConfirmationOtpAsync(email, otp);
                Console.WriteLine($"OTP {otp} sent to email: {email} for email verification.");
                return (true, "OTP resent successfully for email confirmation.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to resend OTP email: {ex.Message}");
                return (false, "Failed to resend OTP email for email confirmation.");
            }
        }

        private async Task StoreOtpAsync(string email, string otp, string purpose)
        {
            _otpStore[email] = (otp, DateTime.UtcNow.AddMinutes(5), DateTime.UtcNow, purpose);
            await Task.CompletedTask;
        }

        private async Task<(string Otp, string Purpose)?> GetStoredOtpAsync(string email)
        {
            if (_otpStore.TryGetValue(email, out var otpData) && otpData.Expiry > DateTime.UtcNow)
            {
                return (otpData.Otp, otpData.Purpose);
            }
            return null;
        }

        private async Task ClearStoredOtpAsync(string email)
        {
            _otpStore.Remove(email);
            await Task.CompletedTask;
        }

        public async Task<User> LoginWithGoogleAsync(string email, string firstName, string lastName)
        {
            var user = await _userRepository.GetUserByEmailAsync(email.ToLower());
            if (user == null)
            {
                var userDto = new UserDTO
                {
                    Email = email,
                    FirstName = firstName ?? "Unknown",
                    LastName = lastName ?? "Unknown",
                    Password = Guid.NewGuid().ToString(),
                    ConfirmPassword = Guid.NewGuid().ToString(),
                    IsTermsAccepted = true,
                    PhoneNumber = "",
                    City = "",
                    BirthOfDate = DateTime.UtcNow.ToString("yyyy-MM-dd")
                };
                await RegisterUserAsync(userDto);
                user = await _userRepository.GetUserByEmailAsync(email.ToLower());
            }
            return user;
        }

        public async Task<UserResultDto> Login(LoginDTO loginDto)
        {
            var user = await _userRepository.GetUserByEmailAsync(loginDto.Email);
            if (user == null) return null;
            var flag = _passwordHasher.VerifyHashedPassword(null, user.PasswordHash, loginDto.Password);
            if (flag != PasswordVerificationResult.Success) return null;

            return new UserResultDto
            {
                DisplayName = $"{user.FirstName} {user.LastName}",
                Email = loginDto.Email,
                Token = await GenerateJwtToken(user)
            };
            
        }

        public async Task<string> GenerateJwtToken(User user)
        {

            var userClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SymmetrisdcSecurityKeyasfasfasfasfasfasfffasfasgbEncoding.UTF8.GetBytes"));


            var token = new JwtSecurityToken(
                issuer: "http://digitalpropertyapi.runasp.net",
                claims: userClaims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: new SigningCredentials(key,SecurityAlgorithms.HmacSha256Signature)

            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> UpdateUser(int id, UserUpdateDto userDto)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return false;
            
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.PhoneNumber = userDto.PhoneNumber;
            user.Email = userDto.Email;
            user.City = userDto.City;

            
            _userRepository.UpdateUser(user);

            return true;
        }
    }
}