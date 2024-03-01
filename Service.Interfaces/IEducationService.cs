using System;
using Entities.Models;
using Shared.DTO;

namespace Service.Interfaces
{
	public interface IEducationService
	{
        Task<IEnumerable<EducationDto>> GetAllEducation(bool trackChanges);
        Task<EducationDto> GetEducationById(Guid educationId, bool trackChanges);
        EducationDto CreateEducation(AddEducationDto addEducationDto);
        void UpdateEducation(Guid Id,UpdateEducationDto updateEducationDto,bool trackChanges);
    }
}

