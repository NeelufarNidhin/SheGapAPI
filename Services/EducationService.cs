using System;
using AutoMapper;
using Entities.Exceptions;
using Entities.Models;
using Interfaces;
using Service.Interfaces;
using Shared.DTO;

namespace Services
{
	public class EducationService : IEducationService
	{
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        public EducationService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
		{
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public EducationDto CreateEducation(AddEducationDto addEducationDto)
        {
            var educationEntity = _mapper.Map<Education>(addEducationDto);
            _repository.Education.CreateEducation(educationEntity);
            _repository.Save();

            var educationToReturn = _mapper.Map<EducationDto>(educationEntity);

            return educationToReturn;
        }

        public async Task<IEnumerable<EducationDto>> GetAllEducation(bool trackChanges)
        {
            var education =  _repository.Education.GetAllEducation(trackChanges);
            var educationDto = _mapper.Map<IEnumerable<EducationDto>>(education);
            return educationDto;
        }

        public EducationDto GetEducationById(Guid Id, bool trackChanges)
        {
            var education = _repository.Education.GetEducationById(Id, trackChanges);

            if (education is null)
            {
                throw new EducationNotFoundException(Id);
            }
            var educationDto = _mapper.Map<EducationDto>(education);
            return educationDto;
        }

        public void UpdateEducation(Guid Id, UpdateEducationDto educationDto, bool trackChanges)
        {
            var educationEntity = _repository.Education.GetEducationById(Id, trackChanges);
            if (educationEntity is null)
            {
                throw new EducationNotFoundException(Id);
            }

            _mapper.Map(educationDto, educationEntity);
            _repository.Save();
        }
    }
}

