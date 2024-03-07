using System;

using Shared.DTO;

namespace Service.Interfaces
{
	public interface IEducationService
	{
        Task<IEnumerable<EducationDto>> GetAllEducation(bool trackChanges);
        EducationDto GetEducationById(Guid Id, bool trackChanges);
        EducationDto CreateEducation(AddEducationDto addEducationDto);
        void UpdateEducation(Guid Id,UpdateEducationDto updateEducationDto, bool trackChanges);
    }
}

