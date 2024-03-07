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

       
		public DbSet<User> User { get; set; }
		public DbSet<JobSeeker> JobSeekers { get; set; }
		public DbSet<Country> Countries { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<Experience> Experience { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<JobType> JobType { get; set; }
        public DbSet<JobSkill> JobSkill { get; set; }
        public DbSet<JobJobSkill> JobJobSkill { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());

            modelBuilder.Entity<JobSeeker>()
                .HasOne(e => e.Country)
                .WithMany()
                .HasForeignKey(e => e.CountryId);

            modelBuilder.Entity<Job>()
                .HasOne(j => j.JobType)   // Job has one JobType
                .WithMany()               // JobType can be associated with many Jobs
                .HasForeignKey(j => j.JobTypeId);  // Foreign key

            modelBuilder.Entity<JobJobSkill>()
                .HasKey(jjs => new { jjs.JobId, jjs.JobSkillId });  //

            modelBuilder.Entity<JobJobSkill>()
                .HasOne(jjs => jjs.Job)
                .WithMany(j => j.JobJobSkill)
                .HasForeignKey(jjs => jjs.JobId);

            modelBuilder.Entity<JobJobSkill>()
               .HasOne(jjs => jjs.JobSkill)
               .WithMany()
               .HasForeignKey(jjs => jjs.JobSkillId);


        }

    }

}

