using System;
namespace Interfaces
{
	public interface IRepositoryManager
	{
		IUserRepository User { get; }
		IJobSeekerRepository JobSeeker { get; }

		void Save();
	}
}

