using System;
using AutoMapper;
using Entities.Exceptions;
using Entities.Models;
using Interfaces;
using Service.Interfaces;
using Shared.DTO;

namespace Services
{
	public class JobTypeService : IJobTypeService
	{
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public JobTypeService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task< JobTypeDto> CreateJobType(AddJobTypeDto addJobTypeDto)
        {
            var jobTypeEntity = _mapper.Map<JobType>(addJobTypeDto);
            _repository.JobType.CreateJobType(jobTypeEntity);
            _repository.Save();
            var jobTypeDto = _mapper.Map<JobTypeDto>(jobTypeEntity);
            return jobTypeDto;
        }

        public void DeleteJobType(Guid Id, bool trackChanges)
        {
            var jobType = _repository.JobType.GetJobTypeById(Id, trackChanges: false);

            if (jobType is null)
            {
                throw new JobNotFoundException(Id);
            }

            _repository.JobType.DeleteJobType(jobType);
            _repository.Save();
        }

        public async Task<IEnumerable<JobTypeDto>> GetAllJobType(bool trackChanges)
        {
            var jobType = await _repository.JobType.GetAllJobType(trackChanges: false);
            var jobTypeDto = _mapper.Map<IEnumerable<JobTypeDto>>(jobType);
            return jobTypeDto;
        }

        public async Task<JobTypeDto> GetJobTypeById(Guid jobTypeId, bool trackChanges)
        {
            var jobType = _repository.JobType.GetJobTypeById(jobTypeId, trackChanges: false);
            if (jobType is null)
            {
                throw new JobTypeNotFoundException(jobTypeId);
            }

            var jobTypeDto = _mapper.Map<JobTypeDto>(jobType);
            return jobTypeDto;
        }

        public void UpdateJobType(Guid Id, UpdateJobTypeDto jobTypeDto, bool trackChanges)
        {
            var jobType = _repository.JobType.GetJobTypeById(Id, trackChanges: true);
            if (jobType is null)
            {
                throw new JobTypeNotFoundException(Id);
            }

            _mapper.Map(jobTypeDto,jobType);
            _repository.Save();
        }
    }
}

