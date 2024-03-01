using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.DTO
{
	public  record UpdateEducationDto
	{
        [Required(ErrorMessage = "Degree is a required !!")]
        public string Degree { get; init; }
        [Required(ErrorMessage = "Degree is a required !!")]
        public string Subject { get;init; }
        [Required(ErrorMessage = "Degree is a required !!")]
        public string College { get; init; }
        public int GraduationYear { get; set; }

        
    }
}

