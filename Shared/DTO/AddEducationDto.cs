using System;
using Entities.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.DTO
{
	public record AddEducationDto
	{

        public Guid JobSeekerId { get; set; }

        [Required(ErrorMessage = "Degree is a required !!")]
        public string Degree { get; set; }
        [Required(ErrorMessage = "FieldOfStudy is a required !!")]
        public string FiledOfStudy { get; set; }
        [Required(ErrorMessage = "College is a required !!")]
        public string College { get; set; }
        public int GraduationYear { get; set; }
       
    }
}

