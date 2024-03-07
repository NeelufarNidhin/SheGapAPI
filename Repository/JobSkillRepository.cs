using System;
using Entities.Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
	public class JobSkillRepository : RepositoryBase<JobSkill> ,IJobSkillRepository
	{
		public JobSkillRepository(RepositoryContext repository) : base (repository)
		{
		}

        public void CreateJobSKill(JobSkill jobSkill)
        {
            Create(jobSkill);
        }

        public void DeleteJobSkill(JobSkill jobSkill)
        {
            Delete(jobSkill);
        }

        public async Task<IEnumerable<JobSkill>> GetAllJobSkill(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.JobSkillName).ToListAsync();
        }

        public JobSkill GetJobSkillById(Guid jobId, bool trackChanges)
        {
            return  FindByCondition(c => c.Id.Equals(jobId), trackChanges).FirstOrDefault();
        }
    }
}

