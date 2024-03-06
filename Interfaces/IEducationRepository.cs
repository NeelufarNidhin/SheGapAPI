using System;
using Entities.Models;

namespace Interfaces
{
	public interface IEducationRepository
	{
        IEnumerable<Education> GetAllEducation(bool trackChanges);
        Education GetEducationById(Guid educationId, bool trackChanges);
        void CreateEducation(Education education);
       
    }
}

