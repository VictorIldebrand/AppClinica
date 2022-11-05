using AutoMapper;
using Contracts.Dto.Employee;
using Contracts.DTO.User;
using Contracts.Entities;
using Contracts.Interfaces.Repositories;
using Contracts.Interfaces.Services;
using Contracts.RequestHandle;
using Contracts.TransactionObjects.Login;
using Contracts.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
namespace Business.Services
{
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
                var employeeExists = await _employeeRepository.CheckIfUserExistsByEmail(registerRequest.Email);
                if (employeeExists)
                    return new RequestResult<EmployeeMinDto>(null, true, RequestAnswer.UserDuplicateCreateError.GetDescription());
                var model = _Mapper.Map<Employee>(registerRequest);
                model.active = true;
                var response = await _employeeRepository.Register(model);
                if (response.id == 0)
                    return new RequestResult<EmployeeMinDto>(null, true, RequestAnswer.UserCreateError.GetDescription());
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

        public async Task<RequestResult<RequestAnswer>> DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<RequestResult<EmployeeDto>> GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<RequestResult<RequestAnswer>> UpdateEmployee(EmployeeDto EmployeeDto)
        {
            throw new NotImplementedException();
        }
    }
}
