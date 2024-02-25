﻿using System;
namespace Entities.Exceptions
{
	public sealed class EmployeeNotFoundException : NotFoundException
	{
		public EmployeeNotFoundException(Guid employeeId) : base($"The employee with Id : {employeeId} doesn't exist")

		{
		}
	}
}

