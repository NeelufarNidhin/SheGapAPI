using System;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using System.Xml.Linq;
using Service.Interfaces;

namespace SheGapAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTypeController : ControllerBase
	{
        private readonly IServiceManager _service;
		public JobTypeController(IServiceManager service)
		{
            _service = service;
		}

        [HttpGet]
        public async Task<IActionResult> GetJobType()
        {
           

            var jobType = await _service.JobTypeService.GetAllJobType(trackChanges: false);
            return Ok(jobType);
        }

        [HttpPost]
        public async Task<IActionResult> CreateJobType([FromBody] AddJobTypeDto jobTypeDto)
        {
            if (jobTypeDto is null)
            {
                return BadRequest("UserDto is null");
            }

            var createJobType = await _service.JobTypeService.CreateJobType(jobTypeDto);
            return CreatedAtRoute("JobTypeById", new { id = createJobType.Id }, createJobType);
            
        }

        [HttpGet("{id:guid}", Name = "JobTypeById")]
        public async Task<IActionResult> GetJobTypeById(Guid id)
        {
            var jobType = _service.JobTypeService.GetJobTypeById(id, trackChanges: false);
            return Ok(jobType);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateJobType(Guid jobTypeId, [FromBody] UpdateJobTypeDto jobTypeDto)
        {
            if (jobTypeDto is null)
            {
                return BadRequest("JobType is Null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            _service.JobTypeService.UpdateJobType(jobTypeId, jobTypeDto, trackChanges: true);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteJobType(Guid Id)
        {

            _service.JobTypeService.DeleteJobType(Id, trackChanges: false);
            return NoContent();
        }
    }
}

