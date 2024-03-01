using System;
using Entities.Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
	public class JobSeekerRepository : RepositoryBase<JobSeeker> , IJobSeekerRepository
    {
		public JobSeekerRepository(RepositoryContext repositoryContext) : base (repositoryContext)
		{
		}

        public  void CreateJobSeeker(JobSeeker jobSeeker)
        {
            Create(jobSeeker);
        }

        public async Task<IEnumerable<JobSeeker>> GetAllJobSeeker(bool trackChanges)
        {
            return await FindAll(trackChanges)
           .OrderBy(c => c.User.FirstName)
           .ToListAsync();
        }

        

        public void UpdateJobSeeker(JobSeeker jobSeeker)
        {
            Update(jobSeeker);
        }

        public async Task<JobSeeker> GetJobSeekerById(Guid jobSeekerId, bool trackChanges)
        {
            return await FindByCondition(c => c.Id.Equals(jobSeekerId), trackChanges).Include(c=>c.Country) .SingleOrDefaultAsync();
        }
    }
}

