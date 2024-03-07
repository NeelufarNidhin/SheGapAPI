using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
	public class JobSkill
	{
        public Guid Id { get; set; }
        [Required( ErrorMessage="Job Skill is Required!!")]
        public string JobSkillName { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;

       
    }
}

