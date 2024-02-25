using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Entities.Models
{
	public class Employee
	{
        [Column("EmployeeId")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "This field is a required !!")]
        public string State { get; set; }
        [Required(ErrorMessage = "This field is a required !!")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Mobile Number is a required !!")]
        [MinLength(10, ErrorMessage = "Please enter 10 digit valid mobile number")]
        public int MobileNumber { get; set; }
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

