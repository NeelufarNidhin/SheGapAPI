using System;
using Entities.Models;

namespace Interfaces
{
	public interface IJobRepository
	{
		Task<IEnumerable<Job>> GetAllJobs(bool trackChanges);
		Job GetJobById(Guid Id, bool trackChanges);
		void AddJob(Job job);
		void DeleteJob(Job job);
	}
}

