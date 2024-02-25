﻿using System;
using Shared.DTO;

namespace Service.Interfaces
{
	public interface IEmployeeService
	{
        Task<IEnumerable<EmployeeDto>> GetAllEmployees(bool trackChanges);
        EmployeeDto GetEmployeeById(Guid employeeId, bool trackChanges);
		EmployeeDto CreateEmployee(AddEmployeeDto employeeDto);
		void UpdateEmployee(Guid employeeId, UpdateEmployeeDto employeeDto,bool trackChanges);
	}
}

