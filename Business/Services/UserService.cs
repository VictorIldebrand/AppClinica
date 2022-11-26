using AutoMapper;
using Contracts.DTO.User;
using Contracts.Entities;
using Contracts.Interfaces.Repositories;
using Contracts.Interfaces.Services;
using Contracts.RequestHandle;
using Contracts.TransactionObjects.Login;
using Contracts.TransactionObjects.User;
using Contracts.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Business.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _Mapper;
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly IEmployeeService _employeeService;
        private readonly IProfessorService _professorService;
        private readonly IStudentService _studentService;
        private readonly IPatientService _patientService;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IProfessorRepository _professorRepository;
        private readonly IPatientRepository _patientRepository;

        public UserService(IMapper Mapper, IConfiguration configuration, IUserRepository userRepository, IEmployeeService employeeService, IProfessorService professorService, IStudentService studentService, IPatientService patientService)
        {
            _Mapper = Mapper;
            _configuration = configuration;
            _userRepository = userRepository;
            _employeeService = employeeService;
            _professorService = professorService;
            _studentService = studentService;
            _patientService = patientService;
        }

        public async Task<RequestResult<LoginResponseDto>> Register(UserDto registerRequest)
        {
            try
            {
                var userExists = await _userRepository.CheckIfUserExistsByEmail(registerRequest.Email);

                if (userExists)
                    return new RequestResult<LoginResponseDto>(null, true, RequestAnswer.UserDuplicateCreateError.GetDescription());

                var model = _Mapper.Map<User>(registerRequest);
                model.Active = true;

                var response = await _userRepository.Register(model);

                if (response.Id == 0)
                    return new RequestResult<LoginResponseDto>(null, true, RequestAnswer.UserCreateError.GetDescription());

                var loginDto = new LoginRequestDto
                {
                    Email = response.Email,
                    Password = response.Password
                };

                var login = await Login(loginDto);

                return new RequestResult<LoginResponseDto>(login.Result);
            }
            catch (Exception ex)
            {
                return new RequestResult<LoginResponseDto>(null, true, ex.Message);
            }
        }

        public async Task<RequestResult<LoginResponseDto>> Login(LoginRequestDto loginRequest)
        {
            try
            {

                User user = new User();
                // Coletar dos 4 repositórios Student, Patient, Professor, Employee
                // Verificar para cada retorno se existe, se existir, montar o obj user e gerar o token
                var employee = await _employeeRepository.GetEmployeeByEmailAndPassword(loginRequest.Email, loginRequest.Password);
                var student = await _studentRepository.GetStudentByEmailAndPassword(loginRequest.Email, loginRequest.Password);
                var patient = await _patientRepository.GetPatientByEmailAndPassword(loginRequest.Email, loginRequest.Password);
                var professor = await _professorRepository.GetProfessorByEmailAndPassword(loginRequest.Email, loginRequest.Password);

                if (employee != null){
                    user.Id = employee.Id;
                    user.Email = employee.Email;
                    user.Password = employee.Password;
                } else if(student != null){
                    user.Id = student.Id;
                    user.Email = student.Email;
                    user.Password = student.Password;
                } else if(patient != null){
                    user.Id = patient.Id;
                    user.Email = patient.Email;
                    user.Password = patient.Password;
                } else if(professor != null){
                    user.Id = professor.Id;
                    user.Email = professor.Email;
                    user.Password = professor.Password;
                } else
                    return new RequestResult<LoginResponseDto>(null, true, RequestAnswer.UserCredError.GetDescription());

                var loginResponse = new LoginResponseDto
                {
                    UserId = user.Id,
                    UserName = user.Name,
                    UserEmail = user.Email,
                    Token = TokenService.GenerateToken(user, _configuration["Settings:JwtSecret"])
                };

                var result = new RequestResult<LoginResponseDto>(loginResponse, false);

                return result;
            }
            catch (Exception ex)
            {
                var msg = ex.Message.Contains("See the inner exception for details") ? ex.InnerException.Message : ex.Message;
                return new RequestResult<LoginResponseDto>(null, true, msg);
            }
        }

        public async Task<RequestResult<UserDto>> GetUserById(int id)
        {
            try
            {
                var model = await _userRepository.GetUserById(id);

                if (model == null)
                    return new RequestResult<UserDto>(null, true, RequestAnswer.UserNotFound.GetDescription());

                var dto = _Mapper.Map<UserDto>(model);
                var result = new RequestResult<UserDto>(dto);

                return result;
            }
            catch (Exception ex)
            {
                return new RequestResult<UserDto>(null, true, ex.Message);
            }
        }

        public async Task<RequestResult<UserDto>> GetUserByEmail(string email)
        {
            try
            {
                var model = await _userRepository.GetUserByEmail(email);

                if (model == null)
                    return new RequestResult<UserDto>(null, true, RequestAnswer.UserNotFound.GetDescription());

                var dto = _Mapper.Map<UserDto>(model);
                var result = new RequestResult<UserDto>(dto);

                return result;
            }
            catch (Exception ex)
            {
                return new RequestResult<UserDto>(null, true, ex.Message);
            }
        }

        public async Task<RequestResult<RequestAnswer>> UpdateUser(UserDto user)
        {
            try
            {
                var userCheck = await _userRepository.CheckIfUserExistsById(user.Id);

                if (!userCheck)
                    return new RequestResult<RequestAnswer>(RequestAnswer.UserNotFound);

                var model = _Mapper.Map<User>(user);
                await _userRepository.UpdateUser(model);

                return new RequestResult<RequestAnswer>(RequestAnswer.UserUpdateSuccess);
            }
            catch (Exception)
            {
                return new RequestResult<RequestAnswer>(RequestAnswer.UserUpdateError, true);
            }
        }
        
        public async Task<RequestResult<RequestAnswer>> DeleteUser(int id)
        {
            try
            {
                await _userRepository.DeleteUser(id);

                return new RequestResult<RequestAnswer>(RequestAnswer.UserDeleteSuccess);
            }
            catch (Exception)
            {
                return new RequestResult<RequestAnswer>(RequestAnswer.UserDeleteError, true);
            }
        }

        public async Task<RequestResult<UserFilterDto>> GetUserFilter() {
            try {
                var employeeModelList = await _employeeService.GetAllEmployees();
                var dtoEmployeeList = _Mapper.Map<FilterInfoDto[]>(employeeModelList);

                var patientModelList = await _patientService.GetAllPatients();
                var dtoPatientList = _Mapper.Map<FilterInfoDto[]>(patientModelList);

                var studentModelList = await _studentService.GetAllStudents();
                var dtoStudentList = _Mapper.Map<FilterInfoDto[]>(studentModelList);

                var professorModelList = await _professorService.GetAllProfessors();
                var dtoProfessorList = _Mapper.Map<FilterInfoDto[]>(professorModelList);

                var resultList = new UserFilterDto {
                    employees = dtoEmployeeList,
                    professors = dtoProfessorList,
                    students = dtoStudentList,
                    patients = dtoPatientList
                };

                var result = new RequestResult<UserFilterDto>(resultList);

                return result;
            } catch (Exception) {
                return new RequestResult<UserFilterDto>(null, true, RequestAnswer.UserFilterError.GetDescription());
            }
        }
    }
}
