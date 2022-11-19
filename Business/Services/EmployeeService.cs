using AutoMapper;
using Contracts.Dto.Employee;
using Contracts.Entities;
using Contracts.Interfaces.Repositories;
using Contracts.Interfaces.Services;
using Contracts.RequestHandle;
using Contracts.TransactionObjects.User;
using Contracts.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
namespace Business.Services {
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _Mapper;
        private readonly IConfiguration _configuration;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IMapper Mapper, IConfiguration configuration, IEmployeeRepository employeeRepository)
        {
            _Mapper = Mapper;
            _configuration = configuration;
            _employeeRepository = employeeRepository;
        }

        public async Task<RequestResult<EmployeeMinDto>> CreateEmployee(EmployeeDto registerRequest)
        {
            try
            {
                var employeeExists = await _employeeRepository.CheckIfEmployeeExistsByEmail(registerRequest.Email);
                if (employeeExists)
                    return new RequestResult<EmployeeMinDto>(null, true, RequestAnswer.EmployeeDuplicateCreateError.GetDescription());
                var model = _Mapper.Map<Employee>(registerRequest);
                model.Active = true;
                var response = await _employeeRepository.Register(model);
                if (response.Id == 0)
                    return new RequestResult<EmployeeMinDto>(null, true, RequestAnswer.EmployeeCreateError.GetDescription());
                var dto = _Mapper.Map<EmployeeMinDto>(response);
                /*var loginDto = new LoginResponseDto
                {
                    Email = response.email,
                    Password = response.password
                };*/
                //var login = await Login(loginDto);
                return new RequestResult<EmployeeMinDto>(dto);
            }
            catch (Exception ex)
            {
                return new RequestResult<EmployeeMinDto>(null, true, ex.Message);
            }
        }

        public async Task<RequestResult<EmployeeDto>> GetEmployeeById(int id)
        {
            try
            {
                var model = await _employeeRepository.GetEmployeeById(id);

                if (model == null)
                    return new RequestResult<EmployeeDto>(null, true, RequestAnswer.EmployeeNotFound.GetDescription());

                var dto = _Mapper.Map<EmployeeDto>(model);
            
                var result = new RequestResult<EmployeeDto>(dto);

                return result;
            }
            catch (Exception ex)
            {
                return new RequestResult<EmployeeDto>(null, true, ex.Message);
            }
        }

        public async Task<RequestResult<EmployeeDto>> GetEmployeeByEmail(string email)
        {
            try
            {
                var model = await _employeeRepository.GetEmployeeByEmail(email);

                if (model == null)
                    return new RequestResult<EmployeeDto>(null, true, RequestAnswer.EmployeeNotFound.GetDescription());

                var dto = _Mapper.Map<EmployeeDto>(model);
                var result = new RequestResult<EmployeeDto>(dto);

                return result;
            }
            catch (Exception ex)
            {
                return new RequestResult<EmployeeDto>(null, true, ex.Message);
            }
        }

        public async Task<RequestResult<RequestAnswer>> UpdateEmployee(EmployeeDto employeeDto)
        {
            try
            {
                var employeeCheck = await _employeeRepository.CheckIfEmployeeExistsById(employeeDto.Id);

                if (!employeeCheck)
                    return new RequestResult<RequestAnswer>(RequestAnswer.EmployeeNotFound);

                var model = _Mapper.Map<Employee>(employeeDto);
                await _employeeRepository.UpdateEmployee(model);

                return new RequestResult<RequestAnswer>(RequestAnswer.EmployeeUpdateSuccess);
            }
            catch (Exception)
            {
                return new RequestResult<RequestAnswer>(RequestAnswer.EmployeeUpdateError, true);
            }
        }
        
        public async Task<RequestResult<RequestAnswer>> DeleteEmployee(int id)
        {
            try
            {
                await _employeeRepository.DeleteEmployee(id);

                return new RequestResult<RequestAnswer>(RequestAnswer.EmployeeDeleteSuccess);
            }
            catch (Exception)
            {
                return new RequestResult<RequestAnswer>(RequestAnswer.EmployeeDeleteError, true);
            }
        }

        public async Task<FilterInfoDto[]> GetAllEmployees() {
            Employee[] employees = await _employeeRepository.GetAllEmployees();

            var array = _Mapper.Map<FilterInfoDto[]>(employees);

            return array;
        }
    }
}
