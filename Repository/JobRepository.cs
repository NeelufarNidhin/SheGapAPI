using System;
using Entities.Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
	public class JobRepository : RepositoryBase<Job>,IJobRepository
	{
		public JobRepository(RepositoryContext repository) : base(repository)
		{
		}

        public void AddJob(Job job)
        {
            Create(job);
        }

        public void DeleteJob(Job job)
        {
            Delete(job);
        }

        public async Task<IEnumerable<Job>> GetAllJobs(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.PostedDate).ToListAsync();
         } 

        public Job GetJobById(Guid jobId, bool trackChanges)
        {
            return  FindByCondition(c => c.Id.Equals(jobId), trackChanges).FirstOrDefault();
        }
    }
}

