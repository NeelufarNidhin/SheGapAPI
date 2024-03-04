using System;
namespace Shared.DTO
{
	public record ExperienceDto(Guid Id,string CompanyName, string JobTitle,DateTime StartDate,DateTime EndDate,string Description,Guid JobSeekerId);
	
}

