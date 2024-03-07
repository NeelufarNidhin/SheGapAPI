using System;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Shared.DTO;

namespace SheGapAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IServiceManager _service;
        public JobController(IServiceManager service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetJob()
        {


            var job = await _service.JobService.GetAllJob(trackChanges: false);
            return Ok(job);
        }

        [HttpPost]
        public async Task<IActionResult> CreateJob([FromBody] AddJobDto jobDto)
        {
            if (jobDto is null)
            {
                return BadRequest("UserDto is null");
            }

            var createJob = await _service.JobService.CreateJob(jobDto);
            return CreatedAtRoute("JobById", new { id = createJob.Id }, createJob);

        }

        [HttpGet("{id:guid}", Name = "JobById")]
        public async Task<IActionResult> GetJobById(Guid id)
        {
            var job = _service.JobService.GetJobById(id, trackChanges: false);
            return Ok(job);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateJob(Guid jobId, [FromBody] UpdateJobDto jobDto)
        {
            if (jobDto is null)
            {
                return BadRequest("Job is Null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            _service.JobService.UpdateJob(jobId, jobDto, trackChanges: true);

            return NoContent();
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteJob(Guid Id)
        {
          
            _service.JobService.DeleteJob(Id,trackChanges:false);
            return NoContent();
        }
    }
}

