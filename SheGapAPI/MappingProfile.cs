using System;
using AutoMapper;
using Entities.Models;
using Shared.DTO;

namespace SheGapAPI
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<ApplicationUser, UserDto>()
				.ReverseMap();
		}
	}
}

