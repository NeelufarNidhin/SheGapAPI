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

			CreateMap<User, UserDto>()
				.ReverseMap();
			CreateMap<Employee, EmployeeDto>().ReverseMap();
			CreateMap<AddEmployeeDto, Employee>().ReverseMap();
			CreateMap<UpdateEmployeeDto, Employee>().ReverseMap();
<<<<<<< HEAD
            CreateMap<Employer, EmployerDto>().ReverseMap();
            CreateMap<AddEmployerDto, Employer>().ReverseMap();
            CreateMap<UpdateEmployerDto, Employer>().ReverseMap();
        }
=======
		}

>>>>>>> EmployeeImplementation
	}
}

