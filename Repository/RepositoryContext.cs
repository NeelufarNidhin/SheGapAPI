using System;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;
using Shared.DTO;

namespace Repository
{
	public class RepositoryContext : IdentityDbContext<User>
	{
		public RepositoryContext(DbContextOptions  options) :base(options)
		{
		}

<<<<<<< HEAD
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
			builder.ApplyConfiguration(new RoleConfiguration());
        }

        public DbSet<User> User { get; set; }

		public DbSet<Employer> Employers { get; set; }

		public DbSet<Employee> Employees { get; set; }

		
	}
=======
		public DbSet<User> User { get; set; }
		public DbSet<JobSeeker> JobSeekers { get; set; }
		public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobSeeker>()
                .HasOne(e => e.Country)
                .WithMany()
                .HasForeignKey(e => e.CountryId);
        }

    }
>>>>>>> JobSeekerImplementation
}

