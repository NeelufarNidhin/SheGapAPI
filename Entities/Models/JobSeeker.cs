using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using Microsoft.AspNetCore.Http;

namespace Entities.Models
{
	public class JobSeeker
	{
        [Column("JobSeekerId")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "City is a required !!")]
        public string City { get; set; }

        [Required(ErrorMessage = "Country is a required !!")]
        public int CountryId { get; set; } // Foreign key referencing Countries table
        public Country Country { get; set; }
       
        [Required(ErrorMessage = "Mobile Number is a required !!")]
        [MinLength(10, ErrorMessage = "Please enter 10 digit valid mobile number")]
        public string MobileNumber { get; set; }
        public string Bio { get; set; }
        public string ImageName { get; set; }
        public bool CreatedStatus { get; set; } = false;
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;

        //Navigation
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
       
        public User? User { get; set; }

        [NotMapped]
        public IFormFile Imagefile { get; set; }
    }
}

