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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace Business.Services {
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _Mapper;
        private readonly IConfiguration _configuration;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly Regex CpfRegex = new Regex("^\\d{11}$");

        public EmployeeService(IMapper Mapper, IConfiguration configuration, IEmployeeRepository employeeRepository)
        {
            _Mapper = Mapper;
            _configuration = configuration;
            _employeeRepository = employeeRepository;
        }

        public async Task<RequestResult<RequestAnswer>> CreateEmployee(EmployeeDto registerRequest)
        {
            try
            {
                var employeeExistsByEmail = await _employeeRepository.CheckIfEmployeeExistsByEmail(registerRequest.Email);
                var employeeExistsByCpf = await _employeeRepository.CheckIfEmployeeExistsByCpf(registerRequest.Cpf);
                
                if (employeeExistsByEmail || employeeExistsByCpf)
                    return new RequestResult<RequestAnswer>(RequestAnswer.EmployeeDuplicateCreateError, true);

                if (!CpfRegex.Match(registerRequest.Cpf).Success)
                    return new RequestResult<RequestAnswer>(RequestAnswer.InvalidCpf, true);
                var model = _Mapper.Map<Employee>(registerRequest);
                model.Active = true;
                
                var response = await _employeeRepository.Register(model);
                if (response.Id == 0)
                    return new RequestResult<RequestAnswer>(RequestAnswer.EmployeeCreateError, true);

                return new RequestResult<RequestAnswer>(RequestAnswer.EmployeeCreateSuccess);
            } catch (Exception ex)
            {
                return new RequestResult<RequestAnswer>(RequestAnswer.EmployeeCreateError, true, ex.Message);
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

        public async Task<RequestResult<RequestAnswer>> UpdateEmployee(EmployeeDto employeeDto, int id)
        {
            try
            {
                bool employeeCheckById = await _employeeRepository.CheckIfEmployeeExistsById(id);
                bool employeeCheckByEmail = false;
                bool employeeCheckByCpf = false;

                if(employeeDto.Email != null)
                    employeeCheckByEmail = await _employeeRepository.CheckIfEmployeeExistsByEmail(employeeDto.Email);
                if(employeeDto.Cpf != null){
                    if (!CpfRegex.Match(employeeDto.Cpf).Success)
                        return new RequestResult<RequestAnswer>(RequestAnswer.InvalidCpf, true);
                    employeeCheckByCpf = await _employeeRepository.CheckIfEmployeeExistsByCpf(employeeDto.Cpf);
                }
                if (employeeCheckByEmail || employeeCheckByCpf)
                    return new RequestResult<RequestAnswer>(RequestAnswer.EmployeeDuplicateCreateError, true);
                if (!employeeCheckById)
                    return new RequestResult<RequestAnswer>(RequestAnswer.EmployeeNotFound, true);


                var model = _Mapper.Map<Employee>(employeeDto);
                await _employeeRepository.UpdateEmployee(model);

                return new RequestResult<RequestAnswer>(RequestAnswer.EmployeeUpdateSuccess);
            }
            catch (Exception ex)
            {
                return new RequestResult<RequestAnswer>(RequestAnswer.EmployeeUpdateError, true, ex.Message);
            }
        }
        
        public async Task<RequestResult<RequestAnswer>> DeleteEmployee(int id)
        {
            try
            {
                await _employeeRepository.DeleteEmployee(id);

                return new RequestResult<RequestAnswer>(RequestAnswer.EmployeeDeleteSuccess);
            }
            catch (Exception ex)
            {
                return new RequestResult<RequestAnswer>(RequestAnswer.EmployeeDeleteError, true, ex.Message);
            }
        }

        public async Task<FilterInfoDto[]> GetAllEmployees() {
            Employee[] employees = await _employeeRepository.GetAllEmployees();

            var array = _Mapper.Map<FilterInfoDto[]>(employees);

            return array;
        }
    }
}
