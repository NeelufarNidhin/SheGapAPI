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
<<<<<<< HEAD
			CreateMap<Employee, EmployeeDto>().ReverseMap();
			CreateMap<AddEmployeeDto, Employee>().ReverseMap();
			CreateMap<UpdateEmployeeDto, Employee>().ReverseMap();


			CreateMap<Employer, EmployerDto>().ReverseMap();
			CreateMap<AddEmployerDto, Employer>().ReverseMap();
			CreateMap<UpdateEmployerDto, Employer>().ReverseMap();
	
;
			CreateMap<UserRegistrationDto, User>().ReverseMap();
        }

=======
			CreateMap<JobSeeker, JobSeekerDto>().ReverseMap();
			CreateMap<AddJobSeekerDto, JobSeeker>().ReverseMap();
			CreateMap<UpdateJobSeekerDto, JobSeeker>().ReverseMap();
		}
>>>>>>> JobSeekerImplementation

	}
}

