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
		private readonly Lazy<IEmployeeService> _employeeService;
        private readonly Lazy<IEmployerService> _employerService;
		private readonly Lazy<IAuthenticationService> _authenticationService;

        public ServiceManager( IRepositoryManager repositoryManager, ILoggerManager logger , IMapper mapper,
			UserManager<User> userManager,IConfiguration configuration)
		{
			_userService = new Lazy<IUserService>(() => new UserService(repositoryManager, logger,mapper));
			_employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repositoryManager, logger, mapper));
            _employerService = new Lazy<IEmployerService>(() => new EmployerService(repositoryManager, logger, mapper));
			_authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper, userManager, configuration));
        }

        public IUserService UserService => _userService.Value;

		public IEmployeeService EmployeeService => _employeeService.Value;

		public IEmployerService EmployerService => _employerService.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}


