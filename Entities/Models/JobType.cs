using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
	public class JobType
	{
		public Guid Id { get; set; }
        [Required(ErrorMessage = "Job Type is Required")]
		public string JobTypeName { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;

        
    }
}

