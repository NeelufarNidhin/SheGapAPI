using System;
using Entities.Models;

namespace Interfaces
{
	public interface IExperienceRepository
	{
		Task <IEnumerable<Experience>> GetAllExperience(bool trackChanges);
		Experience GetExperienceById(Guid experienceId,bool trackChanges);
        void CreateExperience(Experience experience);
		void DeleteExperience(Experience experience);
	}
}

