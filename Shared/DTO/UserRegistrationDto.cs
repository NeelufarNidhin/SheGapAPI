using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.DTO
{
	public record UserRegistrationDto
	{
        [Required(ErrorMessage = "First name is required")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "UserName is required")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        public string Role { get; set; }
      
        public bool TwoFactorEnabled { get; set; }
    }
}

