using System;
using Entities.Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
	public class JobTypeRepository :  RepositoryBase<JobType>, IJobTypeRepository
	{
		public JobTypeRepository(RepositoryContext repository) :  base(repository)
		{
		}

        public void CreateJobType(JobType jobType)
        {
            Create(jobType);
        }

       

        public void DeleteJobType(JobType jobType)
        {
            Delete(jobType);
        }

        public async Task<IEnumerable<JobType>> GetAllJobType(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.JobTypeName).ToListAsync();
        }

        public  JobType GetJobTypeById(Guid jobTypeId, bool trackChanges)
        {
            return  FindByCondition(c => c.Id.Equals(jobTypeId), trackChanges).FirstOrDefault();
        }
    }
}

