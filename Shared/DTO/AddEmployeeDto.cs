using System;
namespace Shared.DTO
{
	public record AddEmployeeDto
	{
        public string ApplicationUserId { get; set; }
      
        public string State { get; set; }
        public string Country { get; set; }
        public int MobileNumber { get; set; }
        public string Bio { get; set; }
        public string ImageName { get; set; }
    }
}

