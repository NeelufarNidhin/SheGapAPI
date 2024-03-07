using System;
using Shared.DTO;

namespace Service.Interfaces
{
	public interface IJobSkillService
	{
        Task<IEnumerable<JobSkillDto>> GetAllJobSkill(bool trackChanges);
        Task<JobSkillDto> GetJobSkillById(Guid jobSkillId, bool trackChanges);
        Task<JobSkillDto >CreateJobSkill(AddJobSkillDto addJobSkillDto);
        void UpdateJobSkill(Guid Id, UpdateJobSkillDto addJobSkillDto, bool trackChanges);
        void DeleteJobSkill(Guid Id, bool trackChanges);

    }
}

