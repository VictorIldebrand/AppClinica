using System;
using Contracts.Interfaces.Services;
using Contracts.RequestHandle;
using System.Threading.Tasks;
using Contracts.Entities;
using Contracts.Dto.Student;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Contracts.Interfaces.Repositories;

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

        public async Task<RequestResult<StudentDto>> CreateStudent(StudentDto StudentDto)
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

        public async Task<RequestResult<StudentDto>> GetStudentById(int id)
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

        public async Task<RequestResult<StudentDto>> GetStudentByEmail(string email)
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

        public async Task<RequestResult<RequestAnswer>> UpdateStudent(StudentDto student)
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

        public async Task<RequestResult<RequestAnswer>> DeleteStudent(int id)
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

        public async Task<RequestResult<StudentDto>> Login(StudentDto loginRequest)
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
    }
}
