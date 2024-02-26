﻿using System;
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
		public AuthenticationController( IServiceManager service)
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

		[HttpPost("login")]
		public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
		{
			if (!await _service.AuthenticationService.ValidateUser(user))
				return Unauthorized();

			return Ok(new { Token = await _service.AuthenticationService.CreateToken() });
		}
	}
}
