﻿using System;
namespace Interfaces
{
	public interface IRepositoryManager
	{
		IUserRepository User { get; }
		IEmployeeRepository Employee { get; }

		void Save();
	}
}

