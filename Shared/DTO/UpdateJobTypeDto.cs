using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.DTO
{
	public record UpdateJobTypeDto
	{
        [Required(ErrorMessage = "Job Type is Required")]
        public string JobTypeName { get; init; }

       
    }
}

