using System;
using AutoMapper;
using Interfaces;
using Service.Interfaces;

namespace Services
{
	public class ServiceManager : IServiceManager
	{
		private readonly Lazy<IUserService> _userService;
		private readonly Lazy<IJobSeekerService> _jobSeekerService;
		public ServiceManager( IRepositoryManager repositoryManager, ILoggerManager logger , IMapper mapper)
		{
			_userService = new Lazy<IUserService>(() => new UserService(repositoryManager, logger,mapper));
            _jobSeekerService = new Lazy<IJobSeekerService>(() => new JobSeekerService(repositoryManager, logger, mapper));
		}

        public IUserService UserService => _userService.Value;

		public IJobSeekerService JobSeekerService => _jobSeekerService.Value;
    }
}


