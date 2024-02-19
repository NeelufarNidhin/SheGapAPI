using System;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shared.DTO;

namespace Repository
{
	public class RepositoryContext : IdentityDbContext<ApplicationUser>
	{
		public RepositoryContext(DbContextOptions  options) :base(options)
		{
		}

		public DbSet<UserDto> ApplicationUser { get; set; }
	}
}

