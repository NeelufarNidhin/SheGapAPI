using System;

using Shared.DTO;

namespace Service.Interfaces
{
	public interface IUserService
	{
       Task <IEnumerable<UserDto>> GetAllUsers(bool trackChanges);
    }
}

