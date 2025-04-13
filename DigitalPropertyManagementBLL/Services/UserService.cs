using DigitalPropertyManagementBLL.Dtos;
using DigitalPropertyManagementBLL.Interfaces;
using GP_DigitalPropertyManegmentApi.Data.Context;
using System;
using System.Threading.Tasks;

namespace DigitalPropertyManagementBLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
        private static readonly Dictionary<string, (string Otp, DateTime Expiry, DateTime LastRequestTime)> _otpStore = new();

        public UserService(IUserRepository userRepository, IEmailService emailService)
        {
            _userRepository = userRepository;
            _emailService = emailService;
        }
  //*******************************************************************************************
        public async Task<bool> RegisterUserAsync(UserDTO userDto)
        {
            if (userDto.Password != userDto.ConfirmPassword)
            {
                return false;
            }

            var existingUser = await _userRepository.GetUserByEmailAsync(userDto.Email);
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
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
                City = userDto.City,
                BirthOfDate = userDto.BirthOfDate,
                IsTermsAccepted = userDto.IsTermsAccepted,
                CreatedAt = DateTime.UtcNow
            };

            await _userRepository.AddUserAsync(user);
            return true;
        }
//*************************************************************************
        public async Task<bool> LoginAsync(LoginDTO loginDto)
        {
            var user = await _userRepository.GetUserByEmailAsync(loginDto.Email);
            if (user == null)
            {
                return false;
            }

            if (user.PasswordHash != loginDto.Password)
            {
                return false;
            }

            return true;
        }
//**********************************************************************************************
        public async Task<string> GenerateOtpAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                return string.Empty;
            }

            var otp = new Random().Next(100000, 999999).ToString();
            return otp;
        }

//***********************************************************************************************************
        public async Task<bool> VerifyOtpAsync(string email, string enteredOtp)
        {
            var storedOtp = await GetStoredOtpAsync(email);

            if (storedOtp == null)
            {
                Console.WriteLine("No OTP found for this email or OTP expired.");
                return false;
            }

            bool isValid = storedOtp == enteredOtp;

            if (isValid)
            {
                await ClearStoredOtpAsync(email);
            }
            else
            {
                Console.WriteLine($"Stored OTP: {storedOtp}, Entered OTP: {enteredOtp}");
            }

            return isValid;
        }
//************************************************************************************************************************
        public async Task<bool> ResetPasswordAsync(string email, string newPassword, string confirmPassword)
        {
            if (newPassword != confirmPassword)
            {
                return false;
            }

            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                return false;
            }

            await _userRepository.UpdateUserPasswordAsync(email, newPassword);
            return true;
        }
//***********************************************************************************************************************
        public async Task<bool> ForgotPasswordAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                return false;
            }

            var otp = await GenerateOtpAsync(email);
            if (string.IsNullOrEmpty(otp))
            {
                return false;
            }

            await StoreOtpAsync(email, otp);

            try
            {
                await _emailService.SendOtpEmailAsync(email, otp);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send OTP email: {ex.Message}");
                return false;
            }

            return true;
        }
//***********************************************************************************************************************
        public async Task<bool> ResendOtpAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                return false;
            }


           
            if (_otpStore.TryGetValue(email, out var otpData))
            {
                
                var timeSinceLastRequest = DateTime.UtcNow - otpData.LastRequestTime;
                if (timeSinceLastRequest.TotalSeconds < 60) 
                {
                    Console.WriteLine($"Please wait {60 - timeSinceLastRequest.TotalSeconds} seconds before requesting a new OTP for email: {email}.");
                    return false; 
                }

               
                if (otpData.Expiry > DateTime.UtcNow)
                {
                    Console.WriteLine($"An OTP is already valid for email: {email}. Please wait until it expires.");
                    return true; 
                }
            }

          
            var otp = await GenerateOtpAsync(email);
            if (string.IsNullOrEmpty(otp))
            {
                return false;
            }

            await StoreOtpAsync(email, otp);

          
            try
            {
                await _emailService.SendOtpEmailAsync(email, otp);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to resend OTP email: {ex.Message}");
                return false;
            }

            return true;
        }

//************************************************************************************************************************
        private async Task StoreOtpAsync(string email, string otp)
        {
            _otpStore[email] = (otp, DateTime.UtcNow.AddMinutes(5), DateTime.UtcNow); // تخزين الـ OTP مع وقت الصلاحية ووقت الطلب
            await Task.CompletedTask;
        }

        private async Task<string> GetStoredOtpAsync(string email)
        {
            if (_otpStore.TryGetValue(email, out var otpData) && otpData.Expiry > DateTime.UtcNow)
            {
                return otpData.Otp;
            }
            return null;
        }
//*********************************************************************************************************************
        private async Task ClearStoredOtpAsync(string email)
        {
            _otpStore.Remove(email);
            await Task.CompletedTask;
        }
    }
}