using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models;
using Microsoft.AspNetCore.Http;

namespace Shared.DTO
{
	public record EmployeeDto
	{
        public Guid Id { get; set; }
       
        public string State { get; set; }
        public string Country { get; set; }      
        public int MobileNumber { get; set; }
        public string Bio { get; set; }
        public string ImageName { get; set; }
       
        //Navigation
        public User User { get; set; }
        public string UserId { get; set; }

        [NotMapped]
        public IFormFile Imagefile { get; set; }
    }
}

