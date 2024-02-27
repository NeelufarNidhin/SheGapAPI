using System;
using Entities.Models;

namespace Interfaces
{
	public interface IEmployeeRepository
	{
		Task <IEnumerable<Employee>> GetAllEmployees(bool trackChanges);
		Employee GetEmployeeById(Guid employeeId, bool trackChanges);
		void CreateEmployee(Employee employee);
		void UpdateEmployee( Employee employee);
		
	}
}

