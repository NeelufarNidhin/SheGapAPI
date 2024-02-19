using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.DTO
{
	public class UserRegistrationDto
	{
        [Required(ErrorMessage = "First name is required")]
        public string? FirstName { get; init; }

        [Required(ErrorMessage = "Last name is required")]
        public string? LastName { get; init; }

        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; init; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; init; }
    }
}

