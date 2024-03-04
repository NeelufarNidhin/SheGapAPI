using System;
using Shared.DTO;

namespace Service.Interfaces
{
	public interface IExperienceService
	{
		Task<IEnumerable<ExperienceDto>> GetAllExperience(bool trackChanges);
		Task<ExperienceDto> GetExperienceById(Guid experienceId, bool trackChanges);
		Task<ExperienceDto> AddExperience(AddExperienceDto addExperienceDto);
		void UpdateExperience(Guid experienceId, UpdateExperienceDto updateExperienceDto, bool trackChanges);
		void DeleteExperience(Guid experienceId,bool trackChanges);
	}
}

