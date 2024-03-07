using System;
using AutoMapper;
using Entities.Exceptions;
using Entities.Models;
using Interfaces;
using Service.Interfaces;
using Shared.DTO;

namespace Services
{
	public class JobService : IJobService
	{
		private readonly IRepositoryManager _repository;
		private readonly ILoggerManager _logger;
		private readonly IMapper _mapper;
		public JobService(IRepositoryManager repository,ILoggerManager logger,IMapper mapper)
		{
			_repository = repository;
			_logger = logger;
			_mapper = mapper;
		}

        public async Task<JobDto> CreateJob(AddJobDto addJobDto)
        {
            var jobEntity =  _mapper.Map<Job>(addJobDto);
            _repository.Job.AddJob(jobEntity);
            _repository.Save();
            var jobDtoToReturn = _mapper.Map<JobDto>(jobEntity);
            return jobDtoToReturn ; 


        }

        public void DeleteJob(Guid jobId, bool trackChanges)
        {
            var job = _repository.Job.GetJobById(jobId,trackChanges:false);

            if(job is null)
            {
                throw new JobNotFoundException(jobId);
            }

            _repository.Job.DeleteJob(job);
            _repository.Save();

        }

        public async Task<IEnumerable<JobDto>> GetAllJob(bool trackChanges)
        {
            var jobs = await _repository.Job.GetAllJobs(trackChanges: false);
            var jobDto = _mapper.Map<IEnumerable<JobDto>>(jobs);
            return jobDto;
        }

        public  async Task<JobDto> GetJobById(Guid jobId, bool trackChanges)
        {
            var job =  _repository.Job.GetJobById(jobId, trackChanges: false);
            if (job is null)
            {
                throw new JobNotFoundException(jobId);
            }

            var jobDto = _mapper.Map<JobDto>(job);
            return jobDto;
        }


            public void UpdateJob(Guid jobId, UpdateJobDto jobDto, bool trackChanges)
            {
            var job = _repository.Job.GetJobById(jobId, trackChanges: true);
            if (job is null)
            {
                throw new JobNotFoundException(jobId);
            }

            _mapper.Map(jobDto,job);
            _repository.Save();


        }
    }
}

