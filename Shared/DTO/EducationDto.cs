using System;
using Entities.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.DTO
{
	public class EducationDto
	{
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Degree is a required !!")]
        public string Degree { get; set; }
        [Required(ErrorMessage = "Degree is a required !!")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Degree is a required !!")]
        public string College { get; set; }
        public int GraduationYear { get; set; }
       

     
        public Guid JobSeekerId { get; set; }
      
    }
}

