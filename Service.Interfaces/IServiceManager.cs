using System;
namespace Service.Interfaces
{
	public interface IServiceManager
	{
		IUserService UserService { get; }
		IEmployeeService EmployeeService { get; }
        IEmployerService EmployerService { get; }
		IAuthenticationService AuthenticationService { get; }
    }
}

