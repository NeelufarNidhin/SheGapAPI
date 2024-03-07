using System;

using Shared.DTO;

namespace Service.Interfaces
{
	public interface IJobSeekerService
	{
        Task<IEnumerable<JobSeekerDto>> GetAllJobSeekers(bool trackChanges);
        JobSeekerDto GetJobSeekerById(Guid Id, bool trackChanges);
        JobSeekerDto CreateJobSeeker(AddJobSeekerDto addJobSeekerDto);
		void UpdateJobSeeker(Guid Id, UpdateJobSeekerDto updateJobSeekerDto, bool trackChanges);
	}
}

