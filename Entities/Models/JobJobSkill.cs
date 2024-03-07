using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
	public class JobJobSkill
	{
        public Guid Id { get; set; }

        [ForeignKey(nameof(Job))]
        public Guid JobId { get; set; }
        public Job Job { get; set; }

        [ForeignKey(nameof(JobSkill))]
        public Guid JobSkillId { get; set; }
        public JobSkill JobSkill { get; set; }
    }
}

