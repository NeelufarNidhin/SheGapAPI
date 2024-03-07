using System;
namespace Service.Interfaces
{
	public interface IServiceManager
	{
		IUserService UserService { get; }
        IEmployerService EmployerService { get; }
		IAuthenticationService AuthenticationService { get; }
		IEducationService EducationService { get; }
		IJobSeekerService JobSeekerService { get; }
		IExperienceService ExperienceService { get; }
		IJobService JobService { get; }
		IJobSkillService JobSkillService { get; }
		IJobTypeService JobTypeService { get; }

	}

}

