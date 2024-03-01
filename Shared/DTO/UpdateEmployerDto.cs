using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.DTO
{
	public class UpdateEmployerDto
	{
        [Required(ErrorMessage = "Company Name is a required !!")]
        public string CompanyName { get; init; }
        public string Location { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
    }
}

