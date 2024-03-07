using System;
namespace Interfaces
{
	public interface IRepositoryManager
	{
		IUserRepository User { get; }
        IEmployerRepository Employer { get; }
		IExperienceRepository Experience { get; }
		IJobSeekerRepository JobSeeker { get; }
		IEducationRepository Education { get; }
		IJobRepository Job { get; }
		IJobSkillRepository JobSkill { get; }
		IJobTypeRepository JobType { get; }
        void Save();
	}
}

