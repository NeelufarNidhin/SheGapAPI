using System;
using Interfaces;

namespace Repository
{
	public class RepositoryManager : IRepositoryManager
	{
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;
		public RepositoryManager(RepositoryContext repositoryContext)
		{
            _repositoryContext = repositoryContext;
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(repositoryContext));
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(repositoryContext));
		}

        public IUserRepository User => _userRepository.Value;

        public IEmployeeRepository Employee => _employeeRepository.Value;

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}

