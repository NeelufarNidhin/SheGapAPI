using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models;
using Microsoft.AspNetCore.Http;

namespace Shared.DTO
{
	public record JobSeekerDto
    {
        public Guid Id { get; set; }
       
        public string City { get; set; }
        public int CountryId { get; set; }
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

