﻿using System;
using Entities.Models;

namespace Interfaces
{
	public interface IEmployerRepository
	{
        Task<IEnumerable<Employer>> GetAllEmployers(bool trackChanges);
        Task<Employer> GetEmployerById(Guid employerId, bool trackChanges);
        void CreateEmployer(Employer employer);
        void UpdateEmployer(Employer employer);
    }
}
