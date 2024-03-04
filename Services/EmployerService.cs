using System;
using AutoMapper;
using Entities.Exceptions;
using Entities.Models;
using Interfaces;
using Service.Interfaces;
using Shared.DTO;

namespace Services
{
    public class EmployerService : IEmployerService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        public EmployerService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public EmployerDto CreateEmployer(AddEmployerDto employerDto)
        {
            var employerEntity = _mapper.Map<Employer>(employerDto);
            _repository.Employer.CreateEmployer(employerEntity);
            _repository.Save();

            var employerToReturn = _mapper.Map<EmployerDto>(employerEntity);

            return employerToReturn;
        }
         
        public async Task< IEnumerable<EmployerDto>> GetAllEmployers(bool trackChanges)
        {
            var employers =  _repository.Employer.GetAllEmployers(trackChanges);
            var employerDto = _mapper.Map<IEnumerable<EmployerDto>>(employers);
            return employerDto;
        }

        public EmployerDto GetEmployerById(Guid employerId, bool trackChanges)
        {
            var employer = _repository.Employer.GetEmployerById(employerId, trackChanges);

            if (employer is null)
            {
                throw new EmployerNotFoundException(employerId);
            }
            var employerDto = _mapper.Map<EmployerDto>(employer);
            return employerDto;
        }

        public void UpdateEmployer(Guid employerId, UpdateEmployerDto employerDto, bool trackChanges)
        {
            var employerEntity = _repository.Employer.GetEmployerById(employerId, trackChanges);
            if (employerEntity is null)
            {
                throw new EmployerNotFoundException(employerId);
            }

            _mapper.Map(employerDto, employerEntity);
            _repository.Save();
        }
    }
}

