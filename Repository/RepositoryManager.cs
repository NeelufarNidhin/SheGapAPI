using System;
using Interfaces;

namespace Repository
{
	public class RepositoryManager : IRepositoryManager
	{
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IJobSeekerRepository> _jobSeekerRepository;
        private readonly Lazy<IEducationRepository> _educationRepository;
        private readonly Lazy<IEmployerRepository> _employerRepository;
        private readonly Lazy<IExperienceRepository> _experienceRepository;
        private readonly Lazy<IJobRepository> _jobRepository;
        private readonly Lazy<IJobSkillRepository> _jobSkillRepository;
        private readonly Lazy<IJobTypeRepository> _jobTypeRepository;

		public RepositoryManager(RepositoryContext repositoryContext)

		{
            _repositoryContext = repositoryContext;
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(repositoryContext));
            _jobSeekerRepository = new Lazy<IJobSeekerRepository>(() => new JobSeekerRepository(repositoryContext));
            _educationRepository = new Lazy<IEducationRepository>(() =>  new EducationRepository(repositoryContext));
            _employerRepository = new Lazy<IEmployerRepository>(() => new EmployerRepository(repositoryContext));
            _experienceRepository = new Lazy<IExperienceRepository>(() => new ExperienceRepository(repositoryContext));
            _jobRepository = new Lazy<IJobRepository>(() => new JobRepository(repositoryContext));
            _jobSkillRepository = new Lazy<IJobSkillRepository>(() => new JobSkillRepository(repositoryContext));
            _jobTypeRepository = new Lazy<IJobTypeRepository>(() => new JobTypeRepository(repositoryContext));


        }



        public IUserRepository User => _userRepository.Value;

        public IJobSeekerRepository JobSeeker => _jobSeekerRepository.Value;

        public IEmployerRepository Employer => _employerRepository.Value;

        public IEducationRepository Education => _educationRepository.Value;

        public IExperienceRepository Experience => _experienceRepository.Value;

        public IJobRepository Job => _jobRepository.Value;

        public IJobSkillRepository JobSkill => _jobSkillRepository.Value;

        public IJobTypeRepository JobType => _jobTypeRepository.Value;

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}

