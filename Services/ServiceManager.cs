﻿using System;
using AutoMapper;
using Interfaces;
using Service.Interfaces;

namespace Services
{
	public class ServiceManager : IServiceManager
	{
		private readonly Lazy<IUserService> _userService;
		private readonly Lazy<IEmployeeService> _employeeService;
		public ServiceManager( IRepositoryManager repositoryManager, ILoggerManager logger , IMapper mapper)
		{
			_userService = new Lazy<IUserService>(() => new UserService(repositoryManager, logger,mapper));
			_employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repositoryManager, logger, mapper));
		}

        public IUserService UserService => _userService.Value;

		public IEmployeeService EmployeeService => _employeeService.Value;
    }
}


