using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.DTO
{
	public class LoginRequestDto
	{
        [Required(ErrorMessage = "User name is required")]
        public string? UserName { get; init; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; init; }
    }
}

