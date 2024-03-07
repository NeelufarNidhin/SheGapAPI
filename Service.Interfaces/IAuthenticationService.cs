using System;
using Microsoft.AspNetCore.Identity;
using Shared.DTO;

namespace Service.Interfaces
{
	public interface IAuthenticationService
	{
		Task<IdentityResult> RegisterUser(UserRegistrationDto userRegistrationDto);
	//	Task<bool> ValidateUser(UserForAuthenticationDto userForAuthentication);
		Task<TokenDto> CreateToken( bool populateExp);
		Task<TokenDto> RefreshToken(TokenDto tokenDto);

        Task<bool> Login(UserForAuthenticationDto model);
        Task<bool> ConfirmEmail(VerifyEmailDto emailDto);
        Task <bool>LoginWithOTP(OtpLoginDto model);
        Task <bool> ResendOTP(ResendOtpDto model);
        Task ForgotPasswordAsync(string email);
        Task<IdentityResult> ResetPasswordAsync(ResetPasswordDto resetDto);
    }
}

