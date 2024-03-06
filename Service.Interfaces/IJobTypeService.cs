using System;
using Shared.DTO;

namespace Service.Interfaces
{
	public interface IJobTypeService
	{
        Task<IEnumerable<JobTypeDto>> GetAllJobType(bool trackChanges);
        Task<JobTypeDto> GetJobTypeById(Guid jobTypeId, bool trackChanges);
        Task<JobTypeDto> CreateJobType(AddJobTypeDto addJobTypeDto);
        void UpdateJobType(Guid Id, UpdateJobTypeDto addJobTypeDto, bool trackChanges);
        void DeleteJobType(Guid Id, bool trackChanges);
    }
}

