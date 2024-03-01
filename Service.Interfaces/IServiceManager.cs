using System;
namespace Service.Interfaces
{
	public interface IServiceManager
	{
		IUserService UserService { get; }
		IJobSeekerService JobSeekerService { get; }
	}
}

