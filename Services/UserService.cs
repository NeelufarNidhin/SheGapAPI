using System;
using AutoMapper;
using Entities.Models;
using Interfaces;
using Service.Interfaces;
using Shared.DTO;

namespace Services
{
	public class UserService : IUserService
	{
		private readonly IRepositoryManager _repository;
		private readonly ILoggerManager _logger;
		private readonly IMapper _mapper;
		public UserService(IRepositoryManager repository, ILoggerManager logger,IMapper mapper)
		{
			_repository = repository;
			_logger = logger;
			_mapper = mapper;
		}

        public async Task <IEnumerable<UserDto>> GetAllUsers(bool trackChanges)
        {
			try
			{
                var users = await _repository.User.GetAllUsers(trackChanges);
                var userDto = _mapper.Map<IEnumerable<UserDto>>(users);
                return userDto;
            }
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong in the {nameof(GetAllUsers)} service method {ex}");
				throw;
			}
				
			
				
			
        }

        
    }
}

