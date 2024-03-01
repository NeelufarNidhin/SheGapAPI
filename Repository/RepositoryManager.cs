using System;
using Interfaces;

namespace Repository
{
	public class RepositoryManager : IRepositoryManager
	{
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IJobSeekerRepository> _jobSeekerRepository;

		public RepositoryManager(RepositoryContext repositoryContext)
		{
            _repositoryContext = repositoryContext;
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(repositoryContext));
            _jobSeekerRepository = new Lazy<IJobSeekerRepository>(() => new JobSeekerRepository(repositoryContext));

		}

        public IUserRepository User => _userRepository.Value;

        public IJobSeekerRepository JobSeeker => _jobSeekerRepository.Value;

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}

