using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
	public class Education
	{
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Degree is a required !!")]
        public string Degree { get; set; }
        [Required(ErrorMessage = "FiledOfStudy is a required !!")]
        public string FieldOfStudy { get; set; }
        [Required(ErrorMessage = "College is a required !!")]
        public string College { get; set; }
        public int GraduationYear{ get; set; }
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(JobSeeker))]
        public Guid JobSeekerId { get; set; }
        public JobSeeker JobSeeker { get; set; }
    }
}

