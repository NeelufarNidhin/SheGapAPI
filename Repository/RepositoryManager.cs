using System;
using Interfaces;

namespace Repository
{
	public class RepositoryManager : IRepositoryManager
	{
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;

        private readonly Lazy<IEmployerRepository> _employerRepository;
<<<<<<< HEAD
    

=======
      
>>>>>>> userAuth

		public RepositoryManager(RepositoryContext repositoryContext)

		{
            _repositoryContext = repositoryContext;
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(repositoryContext));
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(repositoryContext));

            _employerRepository = new Lazy<IEmployerRepository>(() => new EmployerRepository(repositoryContext));
        }

<<<<<<< HEAD

		

=======
>>>>>>> userAuth

        public IUserRepository User => _userRepository.Value;

        public IEmployeeRepository Employee => _employeeRepository.Value;

        public IEmployerRepository Employer => _employerRepository.Value;

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}

