using System;
using AutoMapper;
using Entities.Exceptions;
using Entities.Models;
using Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Service.Interfaces;
using Shared.DTO;

namespace Services
{
    public class ExperienceService : IExperienceService

    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private IMapper _mapper;
       

        public ExperienceService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
           
        }
        public async Task<ExperienceDto> AddExperience(AddExperienceDto addExperienceDto)
        {
            var experienceEntity =  _mapper.Map<Experience>( addExperienceDto);
           _repository.Experience.CreateExperience(experienceEntity);
            _repository.Save();
            var experienceToReturn =  _mapper.Map<ExperienceDto>(experienceEntity);
            return  experienceToReturn;

        }

        public void DeleteExperience(Guid experienceId,bool trackChanges)
        {
            var experience = _repository.Experience.GetExperienceById(experienceId, trackChanges = false);

            if(experience is null)
            {
                throw new ExperienceNotFoundException(experienceId);
            }

            _repository.Experience.DeleteExperience(experience);
            _repository.Save();
        }

        public async Task<IEnumerable<ExperienceDto>> GetAllExperience(bool trackChanges)
        {
            var experience = await  _repository.Experience.GetAllExperience(trackChanges);
            var experienceDto =   _mapper.Map<IEnumerable< ExperienceDto>>(experience);
            return  experienceDto;
        }

        public async Task<ExperienceDto> GetExperienceById(Guid experienceId, bool trackChanges)
        {
            var experience = _repository.Experience.GetExperienceById(experienceId, trackChanges);
            if(experience is null)
            {
                throw new ExperienceNotFoundException(experienceId);
            }

            var experienceDto = _mapper.Map<ExperienceDto>(experience);
            return experienceDto;
        }

        public void UpdateExperience(Guid experienceId, UpdateExperienceDto updateExperienceDto, bool trackChanges)
        {
        
            var experienceEntity = _repository.Experience.GetExperienceById(experienceId,trackChanges);
            if (experienceEntity is null)
            {
                throw new ExperienceNotFoundException(experienceId);
            }
         _mapper.Map(updateExperienceDto, experienceEntity);

          _repository.Save();
           

        }
    }
}

