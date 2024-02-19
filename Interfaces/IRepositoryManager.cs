using System;
namespace Interfaces
{
	public interface IRepositoryManager
	{
		IUserRepository User { get; }

		void Save();
	}
}

