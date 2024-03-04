using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Experience
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "CompanyName is Required")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "JobTitle is Required")]
        public string JobTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(JobSeeker))]
        public Guid JobSeekerId { get; set; }
        public JobSeeker JobSeeker { get; set; }
    }
   
       
}

