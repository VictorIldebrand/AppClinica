using System;
using Contracts.Interfaces.Services;
using Contracts.RequestHandle;
using System.Threading.Tasks;
using Contracts.Entities;
namespace Business.Services
{
	public class StudentService : IStudentService
    {
        Task<RequestResult<Student>> Create(Student student)
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
        public Task<RequestResult<RequestAnswer>> Update(Student student)
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
        public async Task<RequestResult<RequestAnswer>> Delete(int id)
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
        
		public Task<RequestResult<Student>> GetStudentByEmail(string email)
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
		public Task<RequestResult<Student>> GetStudentById(int id)
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
		public Task<RequestResult<Student>> Login(Student loginRequest)
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
		public Task<RequestResult<Student>> Register(Student registerRequest)
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
