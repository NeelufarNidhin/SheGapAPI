﻿using System;
using Entities.Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
	public class EmployeeRepository : RepositoryBase<Employee> , IEmployeeRepository
	{
		public EmployeeRepository(RepositoryContext repositoryContext) : base (repositoryContext)
		{
		}

        public  void CreateEmployee(Employee employee)
        {
            Create(employee);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees(bool trackChanges)
        {
            return await FindAll(trackChanges)
           .OrderBy(c => c.User.FirstName)
           .ToListAsync();
        }

        

        public void UpdateEmployee( Employee employee)
        {
            Update(employee);
        }

        public Employee GetEmployeeById(Guid employeeId, bool trackChanges)
        {
            return FindByCondition(c => c.Id.Equals(employeeId), trackChanges).SingleOrDefault();
        }
    }
}

