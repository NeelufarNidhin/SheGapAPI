using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Shared.DTO;

namespace SheGapAPI.Presentation.Controllers
{
	[Route("api/[controller]")]
	
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly IServiceManager _service;
		public EmployeeController(IServiceManager service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> Getemployees()
		{
			//throw new Exception("Exception");

			var employees = await _service.EmployeeService.GetAllEmployees(trackChanges: false);
			return Ok(employees);
		}

		[HttpPost]
		public async Task<IActionResult> CreateEmployee([FromBody] AddEmployeeDto employeeDto)
		{
			if (employeeDto is null)
			{
				return BadRequest("EmployeeDto is null");
			}

			var createEmployee =  _service.EmployeeService.CreateEmployee(employeeDto);
		   return CreatedAtRoute("EmployeeById", new { id = createEmployee.Id }, createEmployee);
			//return StatusCode(201);
        }

		[HttpGet("{id:guid}" , Name = "EmployeeById")]
		public async Task<IActionResult> GetEmployeeById(Guid id)
		{
			var employee = _service.EmployeeService.GetEmployeeById(id, trackChanges: false);
			return Ok(employee);
		}

		[HttpPut("{id:guid}")]
		public async  Task<IActionResult> UpdateEmployee(Guid employeeId, [FromBody] UpdateEmployeeDto employeeDto)
		{
			if(employeeDto is null)
			{
				return BadRequest("Employee is Null");

			}

			_service.EmployeeService.UpdateEmployee(employeeId, employeeDto, trackChanges: true);

			return NoContent();
		}
	}
}

