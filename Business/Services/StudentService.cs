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
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Business.Services
{
	public class StudentService : IStudentService
    {
        private readonly IMapper _Mapper;
        private readonly IConfiguration _configuration;
        private readonly IStudentRepository _studentRepository;
        private readonly Regex PeriodRegex = new Regex(@"^(10|[1-9])$");

        public StudentService(IMapper Mapper, IConfiguration configuration, IStudentRepository studentRepository)
        {
            _Mapper = Mapper;
            _configuration = configuration;
            _studentRepository = studentRepository;
        }

        public async Task<RequestResult<RequestAnswer>> CreateStudent(StudentDto studentDto)
        {
            try
            {
                var studentExistsByEmail = await _studentRepository.CheckIfStudentExistsByEmail(studentDto.Email);
                var studentExistsByRa = await _studentRepository.CheckIfStudentExistsByRa(studentDto.Ra);

                if (studentExistsByEmail || studentExistsByRa)
                    return new RequestResult<RequestAnswer>(RequestAnswer.StudentDuplicateCreateError, true);

                if (!PeriodRegex.Match(studentDto.Period).Success) {
                    return new RequestResult<RequestAnswer>(RequestAnswer.StudentPeriodError, true);
                }

                var model = _Mapper.Map<Student>(studentDto);
                model.Active = true;

                var response = await _studentRepository.CreateStudent(model);

                if (response.Id == 0)
                    return new RequestResult<RequestAnswer>(RequestAnswer.StudentCreateError, true);

                return new RequestResult<RequestAnswer>(RequestAnswer.StudentCreateSuccess);
            }
            catch (Exception ex)
            {
                return new RequestResult<RequestAnswer>(RequestAnswer.StudentCreateError, true, ex.Message);
            }
        }

        public async Task<RequestResult<StudentMinDto>> GetStudentById(int id)
        {
            try
            {
                var model = await _studentRepository.GetStudentById(id);

                if (model == null)
                    return new RequestResult<StudentMinDto>(null, true, RequestAnswer.StudentNotFound.GetDescription());

                var dto = _Mapper.Map<StudentMinDto>(model);
                var result = new RequestResult<StudentMinDto>(dto);

                return result;
            }
            catch (Exception ex)
            {
                return new RequestResult<StudentMinDto>(null, true, ex.Message);
            }
        }

        public async Task<IEnumerable<FilterInfoDto>> GetAllStudents()
        {
            var students = await _studentRepository.GetAllStudents();

            var array = _Mapper.Map<IEnumerable<Student>, IEnumerable<FilterInfoDto>>(students);

            return array;
        }

        public async Task<RequestResult<StudentMinDto>> GetStudentByEmail(string email)
        {
            try
            {
                var model = await _studentRepository.GetStudentByEmail(email);

                if (model == null)
                    return new RequestResult<StudentMinDto>(null, true, RequestAnswer.StudentNotFound.GetDescription());

                var dto = _Mapper.Map<StudentMinDto>(model);
                var result = new RequestResult<StudentMinDto>(dto);

                return result;
            }
            catch (Exception ex)
            {
                return new RequestResult<StudentMinDto>(null, true, ex.Message);
            }
        }

        public async Task<RequestResult<StudentMinDto>> GetStudentByRa(string ra){
            try
            {
                var model = await _studentRepository.GetStudentByRa(ra);

                if (model == null)
                    return new RequestResult<StudentMinDto>(null, true, RequestAnswer.StudentNotFound.GetDescription());

                var dto = _Mapper.Map<StudentMinDto>(model);
                var result = new RequestResult<StudentMinDto>(dto);

                return result;
            }
            catch (Exception ex)
            {
                return new RequestResult<StudentMinDto>(null, true, ex.Message);
            }
        }

        public async Task<RequestResult<RequestAnswer>> UpdateStudent(StudentDto student)
        {
            try
            {
                bool studentCheck = await _studentRepository.CheckIfStudentExistsById(student.Id);

                if (!studentCheck)
                    return new RequestResult<RequestAnswer>(RequestAnswer.StudentNotFound, true);

                bool studentExistsByEmail = false;
                bool studentExistsByRa = false;

                if(student.Email != null)
                    studentExistsByEmail = await _studentRepository.CheckIfStudentExistsByEmail(student.Email);
                if(student.Ra != null)
                    studentExistsByRa = await _studentRepository.CheckIfStudentExistsByRa(student.Ra);

                if (studentExistsByEmail || studentExistsByRa)
                    return new RequestResult<RequestAnswer>(RequestAnswer.StudentDuplicateCreateError, true);
                if (!PeriodRegex.Match(student.Period).Success)
                    return new RequestResult<RequestAnswer>(RequestAnswer.StudentPeriodError, true);
                var model = _Mapper.Map<Student>(student);
                model.Id = student.Id;
                await _studentRepository.UpdateStudent(model);

                return new RequestResult<RequestAnswer>(RequestAnswer.StudentUpdateSuccess);
            }
            catch (Exception ex)
            {
                return new RequestResult<RequestAnswer>(RequestAnswer.StudentUpdateError, true, ex.Message);
            }
        }

        public async Task<RequestResult<RequestAnswer>> DeleteStudent(int id)
		{
            try
            {
                await _studentRepository.DeleteStudent(id);

                return new RequestResult<RequestAnswer>(RequestAnswer.StudentDeleteSuccess);
            }
            catch (Exception ex)
            {
                return new RequestResult<RequestAnswer>(RequestAnswer.StudentDeleteError, true, ex.Message);
            }
        }

    }
}
