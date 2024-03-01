﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.DTO
{
	public record UpdateJobSeekerDto
    {
        [Required(ErrorMessage = "City is a required !!")]
        public string City { get; init; }
        [Required(ErrorMessage = "Country is a required !!")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Mobile Number is a required !!")]
        [MinLength(10, ErrorMessage = "Please enter 10 digit valid mobile number")]
        public int MobileNumber { get; init; }
        public string Bio { get; set; }
        public string ImageName { get; set; }
    }
}

