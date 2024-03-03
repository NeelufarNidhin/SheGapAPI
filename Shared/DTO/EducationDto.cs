using System;
using Entities.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.DTO
{
	public record EducationDto
	(
        Guid Id, Guid JobSeekerId, string Degree, string FiledOfStudy, string College, int GraduationYear
    );
}













