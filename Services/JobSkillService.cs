using System;
using System.Runtime.Intrinsics.X86;
using AutoMapper;
using Entities.Exceptions;
using Entities.Models;
using Interfaces;
using Service.Interfaces;
using Shared.DTO;

namespace Services
{
	public class JobSkillService : IJobSkillService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public JobSkillService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task <JobSkillDto> CreateJobSkill(AddJobSkillDto addJobSkillDto)
        {
            var jobSkillEntity = _mapper.Map<JobSkill>(addJobSkillDto);
            _repository.JobSkill.CreateJobSKill(jobSkillEntity);
            _repository.Save();
            var jobSkillDto = _mapper.Map<JobSkillDto>(jobSkillEntity);
            return jobSkillDto;
        }

        public void DeleteJobSkill(Guid Id, bool trackChanges)
        {
            var jobSkill = _repository.JobSkill.GetJobSkillById(Id, trackChanges: false);

            if (jobSkill is null)
            {
                throw new JobSkillNotFoundException(Id);
            }

            _repository.JobSkill.DeleteJobSkill(jobSkill);
            _repository.Save();
        }

        public async Task<IEnumerable<JobSkillDto>> GetAllJobSkill(bool trackChanges)
        {
            var jobSkill = await _repository.JobSkill.GetAllJobSkill(trackChanges: false);
            var jobSkillDto = _mapper.Map<IEnumerable<JobSkillDto>>(jobSkill);
            return jobSkillDto;
        }

        public async Task<JobSkillDto> GetJobSkillById(Guid jobSkillId, bool trackChanges)
        {
            var jobSkill = _repository.JobSkill.GetJobSkillById(jobSkillId, trackChanges: false);
            if (jobSkill is null)
            {
                throw new JobSkillNotFoundException(jobSkillId);
            }

            var jobSkillDto = _mapper.Map<JobSkillDto>(jobSkill);
            return jobSkillDto;
        }

        public void UpdateJobSkill(Guid Id, UpdateJobSkillDto jobSkillDto, bool trackChanges)
        {
            var jobSkill = _repository.JobSkill.GetJobSkillById(Id, trackChanges: true);
            if (jobSkill is null)
            {
                throw new JobSkillNotFoundException(Id);
            }
            _mapper.Map(jobSkillDto,   jobSkill);
            _repository.Save();
        }
    }
}

