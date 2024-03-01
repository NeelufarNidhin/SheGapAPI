using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models;
using Microsoft.AspNetCore.Http;

namespace Shared.DTO
{
<<<<<<< HEAD:Shared/DTO/EmployeeDto.cs
	public record EmployeeDto
	(
      Guid Id ,
      string UserId,
      string State ,
      string Country ,
      int MobileNumber ,
      string Bio ,
      string ImageName 
       
=======
	public record JobSeekerDto
    {
        public Guid Id { get; set; }
       
        public string City { get; set; }
        public int CountryId { get; set; }
        public int MobileNumber { get; set; }
        public string Bio { get; set; }
        public string ImageName { get; set; }
>>>>>>> JobSeekerImplementation:Shared/DTO/JobSeekerDto.cs
       
    );
}

