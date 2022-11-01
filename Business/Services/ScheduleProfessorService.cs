using System;
using Contracts.Interfaces.Services;
using Contracts.RequestHandle;
using System.Threading.Tasks;
using Contracts.Entities;
using Contracts.Interfaces.Repositories;
namespace Business.Services
{
    public class ScheduleProfessorService : IScheduleProfessorService
    {
        public Task<RequestResult<ScheduleProfessor>> CreateScheduleProfessor(ScheduleProfessor schedule_professor)
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
        public Task<RequestResult<RequestAnswer>> UpdateScheduleProfessor(ScheduleProfessor schedule_professor)
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
        public Task<RequestResult<RequestAnswer>> DeleteScheduleProfessor(int id)
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
