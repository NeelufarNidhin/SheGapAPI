using System;
using Entities.Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
	public class EducationRepository : RepositoryBase<Education> , IEducationRepository
	{
		public EducationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{
		}

        public void CreateEducation(Education education)
        {
            Create(education);
        }

        public async Task<IEnumerable<Education>> GetAllEducation(bool trackChanges)
        {
            return await FindAll(trackChanges)
           .OrderBy(c => c.College)
           .ToListAsync();
        }

        public async Task<Education> GetEducationById(Guid educationId, bool trackChanges)
        {
            return  FindByCondition(c => c.Id.Equals(educationId), trackChanges).SingleOrDefault();
        }
    }
}

