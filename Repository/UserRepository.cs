using System;
using Entities.Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.DTO;

namespace Repository
{
	public class UserRepository : RepositoryBase<User> , IUserRepository
	{
		public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{
		}

		public async Task< IEnumerable<User>> GetAllUsers(bool trackChanges)
		{
            return await FindAll(trackChanges)
           .OrderBy(c => c.FirstName)
           .ToListAsync();
        }
			
        
    }
}

