using System;
using Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace Shared.DTO
{
	public class EmployerDto
	{
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Company Name is a required !!")]
        public string CompanyName { get; set; }

        public string Location { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
      

        //Navigation
        public string UserId { get; set; }
       
    }
}

