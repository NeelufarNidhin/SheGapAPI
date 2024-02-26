using System;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shared.DTO;

namespace Repository
{
	public class RepositoryContext : IdentityDbContext<User>
	{
		public RepositoryContext(DbContextOptions  options) :base(options)
		{
		}

		public DbSet<User> User { get; set; }
<<<<<<< HEAD
		public DbSet<Employer> Employers { get; set; }
=======
		public DbSet<Employee> Employees { get; set; }
>>>>>>> EmployeeImplementation
		
	}
}

