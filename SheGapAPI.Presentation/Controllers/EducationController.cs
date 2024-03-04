using System;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Shared.DTO;

namespace SheGapAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IServiceManager _service;
        public EducationController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetEducation()
        {
            var education = await _service.EducationService.GetAllEducation(trackChanges: false);
            return Ok(education);

        }

        [HttpPost]
        public async Task<IActionResult> CreateEducation([FromBody] AddEducationDto educationDto)
        {
            if (educationDto is null)
            {
                return BadRequest("Education is null");
            }

            var Education = _service.EducationService.CreateEducation(educationDto);
            return CreatedAtRoute("EducationById", new { id = Education.Id }, Education);
        }

        [HttpGet("{id:guid}", Name = "EducationById")]
        public async Task<IActionResult> GetEducationById(Guid id)
        {
            var education = _service.EducationService.GetEducationById(id, trackChanges: false);
            return Ok(education);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateEducation(Guid educationId, [FromBody] UpdateEducationDto educationDto)
        {
            if (educationDto is null)
            {
                return BadRequest("Education is Null");

            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            _service.EducationService.UpdateEducation(educationId, educationDto, trackChanges: true);

            return NoContent();
        }
    }
}

