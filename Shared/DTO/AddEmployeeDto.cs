using System;
namespace Shared.DTO
{
	public record AddEmployeeDto
	(
        string UserId ,
        string State, 
       string Country ,
       int MobileNumber, 
       string Bio ,
        string ImageName
    );
}

