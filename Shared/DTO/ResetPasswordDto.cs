using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.DTO
{
	public class ResetPasswordDto
	{
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }
}

