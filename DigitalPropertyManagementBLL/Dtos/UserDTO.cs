using System;
using System.ComponentModel.DataAnnotations;

namespace DigitalPropertyManagementBLL.Dtos
{
    public class UserDTO
    {
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        public string? LastName { get; set; } // Nullable

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        public string? PhoneNumber { get; set; } // Nullable

        public string? City { get; set; } // Nullable

        public string? BirthOfDate { get; set; } // Nullable

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required.")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "You must accept the terms and conditions.")]
        public bool IsTermsAccepted { get; set; } // إضافة Required مع رسالة خطأ
    }
}