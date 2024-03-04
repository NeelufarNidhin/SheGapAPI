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
        void Save();
	}
}

