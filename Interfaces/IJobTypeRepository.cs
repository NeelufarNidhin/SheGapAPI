using System;
using Entities.Models;

namespace Interfaces
{
	public interface IJobTypeRepository
	{
		Task<IEnumerable<JobType>> GetAllJobType(bool trackChanges);
		JobType GetJobTypeById(Guid Id,bool trackChanges);
		void CreateJobType(JobType jobType);
		void DeleteJobType(JobType jobType);
	}
}

