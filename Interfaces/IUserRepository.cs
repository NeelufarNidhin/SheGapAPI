using System;
using Entities.Models;
using Shared.DTO;

namespace Interfaces
{
	public interface IUserRepository
	{
       Task <IEnumerable<User>> GetAllUsers(bool trackChanges);
     //  Task<IEnumerable<ApplicationUser>> GetUserById(string id, bool trackChnages);
      //  void Update(ApplicationUser user);
        //void Crrate(ApplicationUser user);

    }
}

