using System;
using Entities.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.DTO
{
	public record UpdateExperienceDto
	{
      
        [Required(ErrorMessage = "CompanyName is Required")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "JobTitle is Required")]
        public string JobTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
      

    }
}

