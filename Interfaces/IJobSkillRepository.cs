using System;
using Entities.Models;

namespace Interfaces
{
	public interface IJobSkillRepository
	{
		Task<IEnumerable<JobSkill>> GetAllJobSkill(bool trackChanges);
		JobSkill GetJobSkillById(Guid Id, bool trackChanges);
		void CreateJobSKill(JobSkill jobSkill);
		void DeleteJobSkill(JobSkill jobSkill);
	}
}

