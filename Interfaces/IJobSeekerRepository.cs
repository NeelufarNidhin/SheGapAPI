using System;
using Entities.Models;

namespace Interfaces
{
	public interface IJobSeekerRepository
	{
		Task <IEnumerable<JobSeeker>> GetAllJobSeeker(bool trackChanges);
		Task <JobSeeker> GetJobSeekerById(Guid jobSeekerId, bool trackChanges);
		void CreateJobSeeker(JobSeeker jobSeeker);
		void UpdateJobSeeker( JobSeeker jobSeeker);
		
	}
}

