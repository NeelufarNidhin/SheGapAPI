using System;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using System.Xml.Linq;
using Service.Interfaces;

namespace SheGapAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	public class JobSkillController : ControllerBase
	{
        private readonly IServiceManager _service;
		public JobSkillController(IServiceManager service)
		{
            _service = service;
		}

        [HttpGet]
        public async Task<IActionResult> GetJobSkill()
        {
            //throw new Exception("Exception");

            var jobSkill = await _service.JobSkillService.GetAllJobSkill(trackChanges: false);
            return Ok(jobSkill);
        }

        [HttpPost]
        public async Task<IActionResult> CreateJobSkill([FromBody] AddJobSkillDto jobSkillDto)
        {
            if (jobSkillDto is null)
            {
                return BadRequest("JobSkillDto is null");
            }

            var createJobSkill = await _service.JobSkillService.CreateJobSkill(jobSkillDto);
            return CreatedAtRoute("JobSkillById", new { id = createJobSkill.Id }, createJobSkill);



        }

        [HttpGet("{id:guid}", Name = "JobSkillById")]
        public async Task<IActionResult> GetJobSkillById(Guid id)
        {
            var jobSkill = _service.JobSkillService.GetJobSkillById(id, trackChanges: false);
            return Ok(jobSkill);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateJobSkill(Guid jobSkillId, [FromBody] UpdateJobSkillDto jobSkillDto)
        {
            if (jobSkillDto is null)
            {
                return BadRequest("JobSkill is Null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            _service.JobSkillService.UpdateJobSkill(jobSkillId, jobSkillDto, trackChanges: true);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteJobSkill(Guid Id)
        {

            _service.JobSkillService.DeleteJobSkill(Id, trackChanges: false);
            return NoContent();
        }
    }
}

