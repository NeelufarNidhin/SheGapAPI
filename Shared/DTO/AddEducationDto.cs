﻿using System;
using Entities.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.DTO
{
	public record AddEducationDto
	{

        public Guid JobSeekerId { get; set; }

        [Required(ErrorMessage = "Degree is a required !!")]
        public string Degree { get; init; }
        [Required(ErrorMessage = "FieldOfStudy is a required !!")]
        public string FieldOfStudy { get; init; }
        [Required(ErrorMessage = "College is a required !!")]
        public string College { get; init; }
        public string GraduationYear { get; set; }
       
    }
}


