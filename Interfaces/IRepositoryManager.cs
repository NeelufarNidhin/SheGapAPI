using System;
namespace Interfaces
{
	public interface IRepositoryManager
	{
		IUserRepository User { get; }
		IEmployeeRepository Employee { get; }
        IEmployerRepository Employer { get; }

        void Save();
	}
}

