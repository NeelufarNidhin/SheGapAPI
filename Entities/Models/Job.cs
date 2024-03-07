using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
	public class Job
	{
		public Guid Id{ get; set; }
        [Required (ErrorMessage = "Jobtitle is required")]
        public string JobTitle  { get; set; }
        [Required(ErrorMessage = "Company Name is required")]
        public string CompanyName  { get; set; }
        public string Location  { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }
        public DateTime PostedDate { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(Employer))]
        public Guid EmployerId { get; set; }
        public Employer Employer { get; set; }

        [ForeignKey(nameof(JobType))]
        public Guid JobTypeId { get; set; }
        public JobType JobType { get; set; }

        public ICollection<JobJobSkill> JobJobSkill { get; set; }



    }
}

