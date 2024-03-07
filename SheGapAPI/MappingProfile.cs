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

			CreateMap<User, UserDto>().ReverseMap();

            CreateMap<Employer, EmployerDto>().ReverseMap();
			CreateMap<AddEmployerDto, Employer>().ReverseMap();
			CreateMap<UpdateEmployerDto, Employer>().ReverseMap();
			CreateMap<UserRegistrationDto, User>().ReverseMap();
            ;
            CreateMap<JobSeeker, JobSeekerDto>().ReverseMap();
			CreateMap<AddJobSeekerDto, JobSeeker>().ReverseMap();
			CreateMap<UpdateJobSeekerDto, JobSeeker>().ReverseMap();
			CreateMap<Experience, ExperienceDto>().ReverseMap();
			CreateMap<AddExperienceDto, Experience>().ReverseMap();
			CreateMap<UpdateExperienceDto, Experience>().ReverseMap();
			CreateMap<Job, JobDto>().ReverseMap();
			CreateMap<AddJobDto, Job>().ReverseMap();
			CreateMap<UpdateJobDto, Job>().ReverseMap();
			CreateMap<JobSkill, JobSkillDto>().ReverseMap();
			CreateMap<AddJobSkillDto, JobSkill>().ReverseMap();
			CreateMap<UpdateJobSkillDto, JobSkill>().ReverseMap();
			CreateMap<JobType, JobTypeDto>().ReverseMap();
			CreateMap<AddJobTypeDto, JobType>().ReverseMap();
			CreateMap<UpdateJobTypeDto, JobType>().ReverseMap();

			CreateMap<Education, EducationDto>().ReverseMap();
			CreateMap<AddEducationDto, Education>().ReverseMap();
			CreateMap<UpdateEducationDto, Education>().ReverseMap();

		}


	}
}

