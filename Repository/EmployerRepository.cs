using System;
using Entities.Models;
using Interfaces;


namespace Repository
{
	public class EmployerRepository : RepositoryBase<Employer>, IEmployerRepository
	{
		public EmployerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

       

        public IEnumerable<Employer> GetAllEmployers(bool trackChanges)
        {
            return  FindAll(trackChanges)
           .OrderBy(c => c.CompanyName).ToList();        
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

