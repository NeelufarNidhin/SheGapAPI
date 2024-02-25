using System;
using AutoMapper;
using Entities.Exceptions;
using Entities.Models;
using Interfaces;
using Service.Interfaces;
using Shared.DTO;

namespace Services
{
	public class EmployeeService : IEmployeeService
	{
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

		public EmployeeService(IRepositoryManager repository,  ILoggerManager logger, IMapper mapper)
		{
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public EmployeeDto CreateEmployee(AddEmployeeDto employeeDto)
        {
            var employeeEntity = _mapper.Map<Employee>(employeeDto);
            _repository.Employee.CreateEmployee(employeeEntity);
            _repository.Save();

            var employeeToReturn = _mapper.Map<EmployeeDto>(employeeEntity);

            return employeeToReturn;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployees(bool trackChanges)
        {
            var employees = await _repository.Employee.GetAllEmployees(trackChanges);
            var employeeDto = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return employeeDto;
        }

        public EmployeeDto GetEmployeeById(Guid employeeId, bool trackChanges)
        {
            var employee = _repository.Employee.GetEmployeeById(employeeId, trackChanges);

            if( employee is null)
            {
                throw new EmployeeNotFoundException(employeeId);
            }
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return employeeDto;
        }

        public void UpdateEmployee(Guid employeeId, UpdateEmployeeDto employeeDto, bool trackChanges)
        {
            var employeeEntity = _repository.Employee.GetEmployeeById(employeeId, trackChanges);
            if(employeeEntity is null)
            {
                throw new EmployeeNotFoundException(employeeId);
            }

            _mapper.Map(employeeDto, employeeEntity);
            _repository.Save();
        }
    }
}

