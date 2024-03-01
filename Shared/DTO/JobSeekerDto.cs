using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models;
using Microsoft.AspNetCore.Http;

namespace Shared.DTO
{

	public record JobSeekerDto
    (
      Guid Id ,
      string UserId,
      string City ,
      int CountryId,
      string MobileNumber ,
      string Bio ,
      string ImageName 
       

	
    );
}

