using System;
using AutoMapper;
using Entities.Exceptions;
using Entities.Models;
using Interfaces;
using Service.Interfaces;
using Shared.DTO;

namespace Services
{
	public class JobSeekerService : IJobSeekerService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

		public JobSeekerService(IRepositoryManager repository,  ILoggerManager logger, IMapper mapper)
		{
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public  JobSeekerDto CreateJobSeeker(AddJobSeekerDto addjobSeekerDto)
        {
            var jobSeekerEntity =  _mapper.Map<JobSeeker>(addjobSeekerDto);
             _repository.JobSeeker.CreateJobSeeker(jobSeekerEntity);
            _repository.Save();

            var jobSeekerToReturn = _mapper.Map<JobSeekerDto>(jobSeekerEntity);

            return jobSeekerToReturn;
        }

        public async Task<IEnumerable<JobSeekerDto>> GetAllJobSeekers(bool trackChanges)
        {
            var jobSeekers = await _repository.JobSeeker.GetAllJobSeeker(trackChanges);
            var jobSeekerDto = _mapper.Map<IEnumerable<JobSeekerDto>>(jobSeekers);
            return jobSeekerDto;
        }

        public JobSeekerDto GetJobSeekerById(Guid Id, bool trackChanges)
        {
            var jobSeeker = _repository.JobSeeker.GetJobSeekerById(Id, trackChanges);

            if(jobSeeker is null)
            {
                throw new JobSeekerNotFoundException(Id);
            }
            var jobSeekerDto = _mapper.Map<JobSeekerDto>(jobSeeker);
            return jobSeekerDto;
        }

        public void UpdateJobSeeker(Guid Id, UpdateJobSeekerDto jobSeekerDto, bool trackChanges)
        {
            var jobSeekerEntity = _repository.JobSeeker.GetJobSeekerById(Id, trackChanges);
            if(jobSeekerEntity is null)
            {
                throw new JobSeekerNotFoundException(Id);
            }

            _mapper.Map(jobSeekerDto, jobSeekerEntity);
            _repository.Save();
        }
    }
}

