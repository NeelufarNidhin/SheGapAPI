using System;
using Entities.Models;

namespace Interfaces
{
	public interface IEducationRepository
	{
        Task<IEnumerable<Education>> GetAllEducation(bool trackChanges);
        Task<Education> GetEducationById(Guid educationId, bool trackChanges);
        void CreateEducation(Education education);
       
    }
}

