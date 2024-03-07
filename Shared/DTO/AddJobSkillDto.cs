using System;
using Entities.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.DTO
{
	public record AddJobSkillDto
	{
       
        [Required(ErrorMessage = "Job Skill is Required!!")]
        public string JobSkillName { get; set; }
       
       
       
    }
}

