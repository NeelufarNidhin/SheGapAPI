using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Shared.DTO;

namespace SheGapAPI.Presentation.Controllers
{
	[Route("api/authentication")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private readonly IServiceManager _service;
		public AuthenticationController(IServiceManager service)
		{
			_service = service;
		}


		[HttpPost]
		//[ServiceFilter(typeof(ValidationFilterAttribute))]
		public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDto userRegistrationDto)
		{
			var result = await _service.AuthenticationService.RegisterUser(userRegistrationDto);
			if (!result.Succeeded)
			{
				foreach (var error in result.Errors)
				{
					ModelState.TryAddModelError(error.Code, error.Description);
				}
				return BadRequest(ModelState);
			}
			return StatusCode(201);
		}


		[HttpGet("ConfirmEmail")]
		public async Task<IActionResult> ConfirmEmail(VerifyEmailDto emailDto)
		{
			var result = await _service.AuthenticationService.ConfirmEmail(emailDto);
			if (result == null)
			{
				return BadRequest("Email doesnt exist");
			}
			return Ok("Emai Verified");


		}

            [HttpPost("login")]
		public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
		{
			var result = await _service.AuthenticationService.Login(user);
			if (!result)
				return BadRequest("User Login with OTP failed");


			return Ok("we have otp to mail please Login");


		}


		[HttpPost("login-2FA")]
		public async Task<IActionResult> LoginWithOTP([FromBody] OtpLoginDto model)
		{

			var result = await _service.AuthenticationService.LoginWithOTP(model);
			if (!result)
				return Unauthorized();
			var tokenDto = await _service.AuthenticationService.CreateToken(populateExp: true);
			return Ok(tokenDto);
		}

		[HttpPost("resend-otp")]
		public async Task<IActionResult> ResendOTP([FromBody] ResendOtpDto model)
		{
			var result = await _service.AuthenticationService.ResendOTP(model);
			if (!result)
				return BadRequest("User Not Found");
			return Ok("New OTP sent successfully");
		}

        [HttpPost("forgotpassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto forgotPassword)
        {
            await _service.AuthenticationService.ForgotPasswordAsync(forgotPassword.Email);

            return NoContent();
        }

        [HttpPost("resetpassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetDto)
        {
            var result = await _service.AuthenticationService.ResetPasswordAsync(resetDto);

            if (result.Succeeded)
            {
                return NoContent();
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return BadRequest(ModelState);
        }
    }
}

