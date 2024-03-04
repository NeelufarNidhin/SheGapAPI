using System;

using Shared.DTO;

namespace Service.Interfaces
{
	public interface IJobSeekerService
	{
        Task<IEnumerable<JobSeekerDto>> GetAllJobSeekers(bool trackChanges);
        JobSeekerDto GetJobSeekerById(Guid jobSeekerId, bool trackChanges);
        JobSeekerDto CreateJobSeeker(AddJobSeekerDto addJobSeekerDto);
		void UpdateJobSeeker(Guid jobSeekerId, UpdateJobSeekerDto updateJobSeekerDto, bool trackChanges);
	}
}

