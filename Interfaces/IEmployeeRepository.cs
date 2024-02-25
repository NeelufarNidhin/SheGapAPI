using System;
using Entities.Models;

namespace Interfaces
{
	public interface IEmployeeRepository
	{
		Task <IEnumerable<Employee>> GetAllEmployees(bool trackChanges);
		Task <Employee> GetEmployeeById(Guid employeeId, bool trackChanges);
		void CreateEmployee(Employee employee);
		void UpdateEmployee(Guid employeeId, Employee employee);
		
	}
}

