using System;
using Entities.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.DTO
{
	public record AddJobTypeDto
	{
        
        [Required(ErrorMessage = "Job Type is Required")]
        public string JobTypeName { get; init; }

        
    }
}

