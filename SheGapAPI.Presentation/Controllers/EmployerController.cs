using System;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Shared.DTO;

namespace SheGapAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
	{
        private readonly IServiceManager _service;
        public EmployerController(IServiceManager service)
		{
			_service = service;
		}


        [HttpGet]
        public async Task<IActionResult> Getemployers()
        {
           

            var employers = await _service.EmployerService.GetAllEmployers(trackChanges: false);
            return Ok(employers);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployer([FromBody] AddEmployerDto employerDto)
        {
            if (employerDto is null)
            {
                return BadRequest("Employer is null");
            }

            var createEmployer = _service.EmployerService.CreateEmployer(employerDto);
            return CreatedAtRoute("EmployerById", new { id = createEmployer.Id }, createEmployer);
        }

        [HttpGet("{id:guid}", Name = "EmployerById")]
        public async Task<IActionResult> GetEmployerById(Guid id)
        {
            var employer = _service.EmployerService.GetEmployerById(id, trackChanges: false);
            return Ok(employer);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateEmployer(Guid employerId, [FromBody] UpdateEmployerDto employerDto)
        {
            if (employerDto is null)
            {
                return BadRequest("Employer is Null");

            }

            _service.EmployerService.UpdateEmployer(employerId, employerDto, trackChanges: true);

            return NoContent();
        }
    }
}

