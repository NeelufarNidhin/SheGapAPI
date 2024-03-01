using System;
namespace Interfaces
{
	public interface IRepositoryManager
	{
		IUserRepository User { get; }
<<<<<<< HEAD
		IEmployeeRepository Employee { get; }
        IEmployerRepository Employer { get; }
=======
		IJobSeekerRepository JobSeeker { get; }
>>>>>>> JobSeekerImplementation

        void Save();
	}
}

