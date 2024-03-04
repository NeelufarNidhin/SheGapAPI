using System;
using Entities.Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
	public class ExperienceRepository : RepositoryBase<Experience>, IExperienceRepository
	{
       
		public ExperienceRepository(RepositoryContext repositoryContext) : base (repositoryContext)
		{
            
		}

       public  void CreateExperience(Experience experience)
        {
           Create(experience);
        }

        public void DeleteExperience(Experience experience)
        {
            Delete(experience);
        }

        public async Task <IEnumerable<Experience>> GetAllExperience(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.CompanyName).ToListAsync();
        }

        public Experience GetExperienceById(Guid experienceId, bool trackChanges)
        {
            return FindByCondition(c => c.Id.Equals(experienceId), trackChanges).SingleOrDefault();
        }
    }
}

