using System;
using Microsoft.AspNetCore.Identity;
using Shared.DTO;

namespace Service.Interfaces
{
	public interface IAuthenticationService
	{
		Task<IdentityResult> RegisterUser(UserRegistrationDto userRegistrationDto);
		Task<bool> ValidateUser(UserForAuthenticationDto userForAuthentication);
		Task<string> CreateToken();
 	}
}

