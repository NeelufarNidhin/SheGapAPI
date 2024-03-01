using System;
using AutoMapper;
using Entities.Models;
using Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Interfaces;

namespace Services
{
	public class ServiceManager : IServiceManager
	{
		private readonly Lazy<IUserService> _userService;
		private readonly Lazy<IEducationService> _educationService;
		private readonly Lazy<IJobSeekerService> _jobSeekerService;
        private readonly Lazy<IEmployerService> _employerService;
		private readonly Lazy<IAuthenticationService> _authenticationService;

        public ServiceManager( IRepositoryManager repositoryManager, ILoggerManager logger , IMapper mapper,
			UserManager<User> userManager,IConfiguration configuration)
		{
			_userService = new Lazy<IUserService>(() => new UserService(repositoryManager, logger,mapper));
			_jobSeekerService= new Lazy<IJobSeekerService>(() => new JobSeekerService(repositoryManager, logger, mapper));
            _employerService = new Lazy<IEmployerService>(() => new EmployerService(repositoryManager, logger, mapper));
			_authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper, userManager, configuration));
			_educationService = new Lazy<IEducationService>(() => new EducationService(repositoryManager, logger, mapper));
        }

        public IUserService UserService => _userService.Value;

		public IEmployerService EmployerService => _employerService.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;
        public IJobSeekerService JobSeekerService => _jobSeekerService.Value;
		public IEducationService EducationService => _educationService.Value;

    }
}


