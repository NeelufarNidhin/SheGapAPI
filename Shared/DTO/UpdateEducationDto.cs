using System;
using System.ComponentModel.DataAnnotations;
using Entities.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.DTO
{
    public record UpdateEducationDto
    {



        [Required(ErrorMessage = "Degree is a required !!")]
        public string Degree { get; init; }
        [Required(ErrorMessage = "FieldOfStudy is a required !!")]
        public string FieldOfStudy { get; init; }
        [Required(ErrorMessage = "College is a required !!")]
        public string College { get; init; }
        public string GraduationYear
        {
            get; set;


        }
    }
}




