using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models;
using Microsoft.AspNetCore.Http;

namespace Shared.DTO
{
	public record EmployeeDto
	(
      Guid Id ,
      string UserId,
      string State ,
      string Country ,
      int MobileNumber ,
      string Bio ,
      string ImageName 
       
       
    );
}

