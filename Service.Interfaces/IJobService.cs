using System;
using Entities.Models;
using Shared.DTO;

namespace Service.Interfaces
{
	public interface IJobService
	{
		Task<IEnumerable<JobDto>> GetAllJob(bool trackChanges);
		Task<JobDto> GetJobById(Guid jobId, bool trackChanges);
        Task<JobDto> CreateJob(AddJobDto addJobDto);
        void UpdateJob(Guid jobId,UpdateJobDto addJobDto, bool trackChanges);
        void DeleteJob(Guid jobId, bool trackChanges);
    }
}

