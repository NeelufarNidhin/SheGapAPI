using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Entities.Models
{
	public class User : IdentityUser
	{
        [Required(ErrorMessage = "First Name is a required !!")]
        [MaxLength(30, ErrorMessage = "Maximum length for the the Name is 30 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is a required !!")]
        [MaxLength(30, ErrorMessage = "Maximum length for the the Name is 30 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Role is a required !!")]
        public string Role { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsProfile { get; set; }
    }
}

