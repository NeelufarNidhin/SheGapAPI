using System;
using Entities.Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
	public class EmployerRepository : RepositoryBase<Employer>, IEmployerRepository
	{
		public EmployerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

       

        public async Task<IEnumerable<Employer>> GetAllEmployers(bool trackChanges)
        {
            return await FindAll(trackChanges)
           .OrderBy(c => c.CompanyName)
           .ToListAsync();
        }

        public  Employer GetEmployerById(Guid employerId, bool trackChanges)
        {
            return  FindByCondition(c => c.Id.Equals(employerId), trackChanges).SingleOrDefault();
        }

        public void CreateEmployer(Employer employer)
        {
            Create(employer);
        }

        public void UpdateEmployer(Employer employer)
        {
            Update(employer);
        }
    }
}

