using System;
using Entities.Models;

namespace Interfaces
{
	public interface IEmployerRepository
	{
        IEnumerable<Employer> GetAllEmployers(bool trackChanges);
        Employer GetEmployerById(Guid employerId, bool trackChanges);
        void CreateEmployer(Employer employer);
        void UpdateEmployer(Employer employer);
    }
}

