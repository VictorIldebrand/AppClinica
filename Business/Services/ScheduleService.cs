using System;
using Contracts.RequestHandle;
using System.Threading.Tasks;
using Contracts.Entities;
using Contracts.Interfaces.Repositories;
using Contracts.Dto.Schedule;
using Contracts.Interfaces.Services;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Contracts.Utils;

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
                var model = _Mapper.Map<Schedule>(ScheduleDto);
                model.Active = true;
                var response = await _scheduleRepository.CreateSchedule(model);
                if (response.Id == 0)
                    return new RequestResult<RequestAnswer>(RequestAnswer.ScheduleCreateError, true);

                return new RequestResult<RequestAnswer>(RequestAnswer.ScheduleCreateSuccess);
            }
            catch (Exception)
            {
                return new RequestResult<RequestAnswer>(RequestAnswer.ScheduleCreateError, true);
            }
        }

        public async Task<RequestResult<ScheduleDto>> GetScheduleById(int id)
        {
            try
            {
                var model = await _scheduleRepository.GetScheduleById(id);

                if (model == null)
                    return new RequestResult<ScheduleDto>(null, true, RequestAnswer.ScheduleNotFound.GetDescription());

                var dto = _Mapper.Map<ScheduleDto>(model);
                var result = new RequestResult<ScheduleDto>(dto);

                return result;
            }
            catch (Exception ex)
            {
                return new RequestResult<ScheduleDto>(null, true, ex.Message);
            }
        }

        public async Task<RequestResult<RequestAnswer>> UpdateSchedule(ScheduleDto schedule, int id)
        {
            try
            {
                var scheduleCheck = await _scheduleRepository.CheckIfScheduleExistsById(id);

                if (!scheduleCheck)
                    return new RequestResult<RequestAnswer>(RequestAnswer.ScheduleNotFound, true);

                var model = _Mapper.Map<Schedule>(schedule);
                await _scheduleRepository.UpdateSchedule(model);

                return new RequestResult<RequestAnswer>(RequestAnswer.ScheduleUpdateSuccess);
            }
            catch (Exception)
            {
                return new RequestResult<RequestAnswer>(RequestAnswer.ScheduleUpdateError, true);
            }
        }
        
        public async Task<RequestResult<RequestAnswer>> DeleteSchedule(int id)
        {
            try
            {
                await _scheduleRepository.DeleteSchedule(id);

                return new RequestResult<RequestAnswer>(RequestAnswer.ScheduleDeleteSuccess);
            }
            catch (Exception)
            {
                return new RequestResult<RequestAnswer>(RequestAnswer.ScheduleDeleteError, true);
            }
        }
    }
}
