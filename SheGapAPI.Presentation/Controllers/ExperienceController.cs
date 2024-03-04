using System;
using Entities.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Shared.DTO;

namespace SheGapAPI.Presentation.Controllers
{
	[Route("api/controller")]
	[ApiController]
	public class ExperienceController : ControllerBase
	{
		private readonly IServiceManager _service;
		public ExperienceController(IServiceManager service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllExperience()
		{
			var experience = await _service.ExperienceService.GetAllExperience(trackChanges: false);
			return Ok(experience);

		}

		[HttpGet("{id:guid}",Name ="ExperienceById")]
		public async Task<IActionResult> GetExperienceById(Guid experienceId)
		{
			var experience = await _service.ExperienceService.GetExperienceById(experienceId, trackChanges: false);
			if(experience is null)
			{
				return BadRequest("Experience not found");
			}
			return Ok(experience);
		}

		[HttpPost]
		public async Task<IActionResult> CreateExperience([FromBody] AddExperienceDto addExperienceDto)
		{
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            if (addExperienceDto is null)
			{
				return BadRequest("Add ExperienceDto is null");
			}
			var experience = await _service.ExperienceService.AddExperience(addExperienceDto);
			return CreatedAtRoute("ExperienceById", new { id = experience.Id }, experience);

		}

		[HttpPut]
		public async Task<IActionResult> UpdateExperience(Guid experienceId,[FromBody] UpdateExperienceDto updateExperience)
		{
			if(updateExperience is null)
			{
                return BadRequest("Add ExperienceDto is null");
            }
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            _service.ExperienceService.UpdateExperience(experienceId,updateExperience,trackChanges:true);
			return NoContent();

		}

		[HttpDelete]
		public async Task<IActionResult> DeleteExperience(Guid experienceId)
		{
			_service.ExperienceService.DeleteExperience(experienceId, trackChanges: false);
			return NoContent();
		}
	}
}

