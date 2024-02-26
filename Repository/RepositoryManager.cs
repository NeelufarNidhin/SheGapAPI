using System;
using Interfaces;

namespace Repository
{
	public class RepositoryManager : IRepositoryManager
	{
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;
<<<<<<< HEAD
        private readonly Lazy<IEmployerRepository> _employerRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
=======

		public RepositoryManager(RepositoryContext repositoryContext)
>>>>>>> EmployeeImplementation
		{
            _repositoryContext = repositoryContext;
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(repositoryContext));
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(repositoryContext));
<<<<<<< HEAD
            _employerRepository = new Lazy<IEmployerRepository>(() => new EmployerRepository(repositoryContext));
        }
=======

		}
>>>>>>> EmployeeImplementation

        public IUserRepository User => _userRepository.Value;

        public IEmployeeRepository Employee => _employeeRepository.Value;

        public IEmployerRepository Employer => _employerRepository.Value;

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}

