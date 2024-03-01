using System;
using Interfaces;

namespace Repository
{
	public class RepositoryManager : IRepositoryManager
	{
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IJobSeekerRepository> _jobSeekerRepository;
        private readonly Lazy<IEducationRepository> _educationRepository;
        private readonly Lazy<IEmployerRepository> _employerRepository;


		public RepositoryManager(RepositoryContext repositoryContext)

		{
            _repositoryContext = repositoryContext;
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(repositoryContext));
            _jobSeekerRepository = new Lazy<IJobSeekerRepository>(() => new JobSeekerRepository(repositoryContext));
            _educationRepository = new Lazy<IEducationRepository>(() =>  new EducationRepository(repositoryContext));
            _employerRepository = new Lazy<IEmployerRepository>(() => new EmployerRepository(repositoryContext));
        }



        public IUserRepository User => _userRepository.Value;

        public IJobSeekerRepository JobSeeker => _jobSeekerRepository.Value;

        public IEmployerRepository Employer => _employerRepository.Value;

        public IEducationRepository Education => _educationRepository.Value;

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}

