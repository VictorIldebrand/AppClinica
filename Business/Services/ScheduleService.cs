using System;
using Contracts.RequestHandle;
using System.Threading.Tasks;
using Contracts.Entities;
using Contracts.Interfaces.Repositories;
using Contracts.Dto.Schedule;
using Contracts.Interfaces.Services;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace Business.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IMapper _Mapper;
        private readonly IConfiguration _configuration;
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleService(IMapper Mapper, IConfiguration configuration, IScheduleRepository scheduleRepository)
        {
            _Mapper = Mapper;
            _configuration = configuration;
            _scheduleRepository = scheduleRepository;
        }

        public async Task<RequestResult<RequestAnswer>> CreateSchedule(ScheduleDto ScheduleDto)
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

        public async Task<RequestResult<ScheduleDto>> GetScheduleById(int id)
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

        public async Task<RequestResult<RequestAnswer>> UpdateSchedule(ScheduleDto ScheduleDto)
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
        
        public async Task<RequestResult<RequestAnswer>> DeleteSchedule(int id)
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
