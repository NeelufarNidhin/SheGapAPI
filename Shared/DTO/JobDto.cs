using System;
using Entities.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.DTO
{
	//public record JobDto(Guid Id,string JobTitle, string CompanyName,string Location,
 //       string Description,string Status,Guid JobTypeId,Guid JobSkillId ,Guid EmployerId);

	public class JobDto
	{
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Jobtitle is required")]
        public string JobTitle { get; set; }
        [Required(ErrorMessage = "Company Name is required")]
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }
       

       
        public Guid EmployerId { get; set; }
       

      
        public Guid JobTypeId { get; set; }
      

        public ICollection<JobJobSkill> JobJobSkill { get; set; }

    }



}

