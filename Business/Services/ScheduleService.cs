using System;
using Contracts.RequestHandle;
using System.Threading.Tasks;
using Contracts.Entities;
using Contracts.Interfaces.Repositories;
namespace Business.Services
{
    public class ScheduleService : IScheduleService
    {
        public Task<RequestResult<Schedule>> CreateSchedule(Schedule schedule)
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
        public Task<RequestResult<RequestAnswer>> UpdateSchedule(Schedule schedule)
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
        public Task<RequestResult<RequestAnswer>> DeleteSchedule(int id)
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
