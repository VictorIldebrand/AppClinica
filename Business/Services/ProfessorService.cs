using System;
using Contracts.Interfaces.Services;
using Contracts.RequestHandle;
using System.Threading.Tasks;
using Contracts.Entities;
using Contracts.Interfaces.Repositories;
namespace Business.Services
{
    public class ProfessorService : IProfessorService
    {
        public Task<RequestResult<Professor>> CreateProfessor(Professor professor)
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
        public Task<RequestResult<RequestAnswer>> UpdateProfessor(Professor professor)
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
        public Task<RequestResult<RequestAnswer>> DeleteProfessor(int id)
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
