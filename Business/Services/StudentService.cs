using System;
using Contracts.Interfaces.Services;
using Contracts.RequestHandle;
using System.Threading.Tasks;
using Contracts.Entities;
using Contracts.Dto.Student;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Contracts.Interfaces.Repositories;
using Contracts.Utils;
using Contracts.TransactionObjects.User;

namespace Business.Services
{
	public class StudentService : IStudentService
    {
        private readonly IMapper _Mapper;
        private readonly IConfiguration _configuration;
        private readonly IStudentRepository _studentRepository;

        public StudentService(IMapper Mapper, IConfiguration configuration, IStudentRepository studentRepository)
        {
            _Mapper = Mapper;
            _configuration = configuration;
            _studentRepository = studentRepository;
        }

        public async Task<RequestResult<StudentMinDto>> CreateStudent(StudentDto studentDto)
        {
            try
            {
                var studentExists = await _studentRepository.CheckIfStudentExistsByEmail(studentDto.Email);

                if (studentExists)
                    return new RequestResult<StudentMinDto>(null, true, RequestAnswer.StudentDuplicateCreateError.GetDescription());

                var model = _Mapper.Map<Student>(studentDto);
                model.Active = true;

                var response = await _studentRepository.CreateStudent(model);

                if (response.Id == 0)
                    return new RequestResult<StudentMinDto>(null, true, RequestAnswer.StudentCreateError.GetDescription());

                var dto = _Mapper.Map<StudentMinDto>(response);

                return new RequestResult<StudentMinDto>(dto);
            }
            catch (Exception ex)
            {
                return new RequestResult<StudentMinDto>(null, true, ex.Message);
            }
        }

        public async Task<RequestResult<StudentDto>> GetStudentById(int id)
        {
            try
            {
                var model = await _studentRepository.GetStudentById(id);

                if (model == null)
                    return new RequestResult<StudentDto>(null, true, RequestAnswer.StudentNotFound.GetDescription());

                var dto = _Mapper.Map<StudentDto>(model);
                var result = new RequestResult<StudentDto>(dto);

                return result;
            }
            catch (Exception ex)
            {
                return new RequestResult<StudentDto>(null, true, ex.Message);
            }
        }

        public async Task<FilterInfoDto[]> GetAllStudents()
        {
            Student[] students = await _studentRepository.GetAllStudents();

            var array = _Mapper.Map<FilterInfoDto[]>(students);

            return array;
        }

        public async Task<RequestResult<StudentDto>> GetStudentByEmail(string email)
        {
            try
            {
                var model = await _studentRepository.GetStudentByEmail(email);

                if (model == null)
                    return new RequestResult<StudentDto>(null, true, RequestAnswer.StudentNotFound.GetDescription());

                var dto = _Mapper.Map<StudentDto>(model);
                var result = new RequestResult<StudentDto>(dto);

                return result;
            }
            catch (Exception ex)
            {
                return new RequestResult<StudentDto>(null, true, ex.Message);
            }
        }

        public async Task<RequestResult<StudentDto>> GetStudentByRa(string ra){
            try
            {
                var model = await _studentRepository.GetStudentByRa(ra);

                if (model == null)
                    return new RequestResult<StudentDto>(null, true, RequestAnswer.StudentNotFound.GetDescription());

                var dto = _Mapper.Map<StudentDto>(model);
                var result = new RequestResult<StudentDto>(dto);

                return result;
            }
            catch (Exception ex)
            {
                return new RequestResult<StudentDto>(null, true, ex.Message);
            }
        }

        public async Task<RequestResult<RequestAnswer>> UpdateStudent(StudentDto student)
        {
            try
            {
                var studentCheck = await _studentRepository.CheckIfStudentExistsById(student.Id);

                if (!studentCheck)
                    return new RequestResult<RequestAnswer>(RequestAnswer.StudentNotFound);

                var model = _Mapper.Map<Student>(student);
                await _studentRepository.UpdateStudent(model);

                return new RequestResult<RequestAnswer>(RequestAnswer.StudentUpdateSuccess);
            }
            catch (Exception)
            {
                return new RequestResult<RequestAnswer>(RequestAnswer.StudentUpdateError, true);
            }
        }

        public async Task<RequestResult<RequestAnswer>> DeleteStudent(int id)
		{
            try
            {
                await _studentRepository.DeleteStudent(id);

                return new RequestResult<RequestAnswer>(RequestAnswer.StudentDeleteSuccess);
            }
            catch (Exception)
            {
                return new RequestResult<RequestAnswer>(RequestAnswer.StudentDeleteError, true);
            }
        }

        public async Task<RequestResult<RequestAnswer>> RequestPatient()
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // public async Task<RequestResult<LoginResponseDto>> Login(StudentDto studentDto)
		// {
        //     try
        //     {
        //         var student = await _studentRepository.GetStudentByEmailAndPassword(studentDto.Email, studentDto.Password);

        //         if (student == null)
        //             return new RequestResult<LoginResponseDto>(null, true, RequestAnswer.StudentCredError.GetDescription());

        //         var loginResponse = new LoginResponseDto
        //         {
        //             UserId = student.id,
        //             UserName = student.name,
        //             UserEmail = student.email,
        //             Token = TokenService.GenerateStudentToken(student, _configuration["Settings:JwtSecret"])
        //         };

        //         var result = new RequestResult<LoginResponseDto>(loginResponse, false);

        //         return result;
        //     }
        //     catch (Exception ex)
        //     {
        //         var msg = ex.Message.Contains("See the inner exception for details") ? ex.InnerException.Message : ex.Message;
        //         return new RequestResult<LoginResponseDto>(null, true, msg);
        //     }
        // }
    }
}
