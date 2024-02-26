using System;
using Shared.DTO;

namespace Service.Interfaces
{
	public interface IEmployerService
	{
        Task<IEnumerable<EmployerDto>> GetAllEmployers(bool trackChanges);
        EmployerDto GetEmployerById(Guid employerId, bool trackChanges);
        EmployerDto CreateEmployer(AddEmployerDto employerDto);
        void UpdateEmployer(Guid employerId, UpdateEmployerDto employerDto, bool trackChanges);
    }
}

