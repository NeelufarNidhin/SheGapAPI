using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.DTO
{
	public record UpdateJobSkillDto
	{

        [Required(ErrorMessage = "Job Skill is Required!!")]
        public string JobSkillName { get; set; }
    }
}

