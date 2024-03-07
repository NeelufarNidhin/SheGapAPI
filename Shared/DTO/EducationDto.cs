using System;
using Entities.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.DTO
{
    public record EducationDto(Guid Id, string Degree,string FieldOfStudy, string College, string GraduationYear, Guid JobSeekerId);

   


}












