using System;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace SheGapAPI.Presentation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IServiceManager _service;
		public UserController(IServiceManager service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task <IActionResult> GetUsers()
		{
			try
			{
                var users = await _service.UserService.GetAllUsers(trackChanges: false);
                return Ok(users);
            }

			catch 
			{
				return StatusCode(500,"Internel Server Error");
			}
				
			
		}
	}
}

