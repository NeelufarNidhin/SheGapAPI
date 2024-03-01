using System;
namespace Service.Interfaces
{
	public interface IServiceManager
	{
		IUserService UserService { get; }
<<<<<<< HEAD
		IEmployeeService EmployeeService { get; }
        IEmployerService EmployerService { get; }
		IAuthenticationService AuthenticationService { get; }
    }
=======
		IJobSeekerService JobSeekerService { get; }
	}
>>>>>>> JobSeekerImplementation
}

