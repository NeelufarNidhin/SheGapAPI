using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.DTO
{
	public class AddEmployerDto
	{
        public string UserId { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
    }
}

