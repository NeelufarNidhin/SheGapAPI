using System;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Shared.DTO;

namespace SheGapAPI.Presentation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class JobSeekerController : ControllerBase
	{
		private readonly IServiceManager _service;
		public JobSeekerController(IServiceManager service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetJobSeeker()
		{
			//throw new Exception("Exception");

			var jobSeekers = await _service.JobSeekerService.GetAllJobSeekers(trackChanges: false);
			return Ok(jobSeekers);
		}

		[HttpPost]
		public async Task<IActionResult> CreateJobSeeker([FromBody] AddJobSeekerDto jobSeekerDto)
		{
			if (jobSeekerDto is null)
			{
				return BadRequest("UserDto is null");
			}

			var createJobSeeker = _service.JobSeekerService.CreateJobSeeker(jobSeekerDto);
			return CreatedAtRoute("JobSeekerById", new { id = createJobSeeker.Id }, createJobSeeker);
		}

		[HttpGet("{id:guid}")]
		public async Task<IActionResult> GetJobSeekerById(Guid id)
		{
			var jobSeeker = _service.JobSeekerService.GetJobSeekerById(id, trackChanges: false);
			return Ok(jobSeeker);
		}

		[HttpPut("{id:guid}")]
		public async  Task<IActionResult> UpdateJobSeeker(Guid jobSeekerId, [FromBody] UpdateJobSeekerDto jobSeekerDto)
		{
			if(jobSeekerDto is null)
			{
				return BadRequest("JobSeeker is Null");
            }

			_service.JobSeekerService.UpdateJobSeeker(jobSeekerId, jobSeekerDto, trackChanges: true);

			return NoContent();
		}
	}
}

