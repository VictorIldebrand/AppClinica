using System;
using Contracts.Interfaces.Services;
using Contracts.RequestHandle;
using System.Threading.Tasks;
using Contracts.Entities;
using Contracts.Interfaces.Repositories;
using Contracts.Dto.ScheduleProfessor;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Contracts.Utils;
using Contracts.Dto.Schedule;
using Contracts.Dto.Professor;

namespace Business.Services
{
    public class ScheduleProfessorService : IScheduleProfessorService
    {
        private readonly IMapper _Mapper;
        private readonly IConfiguration _configuration;
        private readonly IScheduleProfessorRepository _scheduleProfessorRepository;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IProfessorRepository _professorRepository;

        public ScheduleProfessorService(IMapper Mapper, IConfiguration configuration, IScheduleProfessorRepository scheduleProfessorRepository, IScheduleRepository scheduleRepository, IProfessorRepository professorRepository)
        {
            _Mapper = Mapper;
            _configuration = configuration;
            _scheduleProfessorRepository = scheduleProfessorRepository;
            _scheduleRepository = scheduleRepository;
            _professorRepository = professorRepository;
        }

        public async Task<RequestResult<RequestAnswer>> CreateScheduleProfessor(ScheduleProfessorDto ScheduleProfessorDto)
        {
            try
            {
                Professor professor = await _professorRepository.GetProfessorById(ScheduleProfessorDto.ProfessorId);
                if (professor == null)
                    return new RequestResult<RequestAnswer>(RequestAnswer.ScheduleProfessorCreateError, true);

                Schedule schedule = await _scheduleRepository.GetScheduleById(ScheduleProfessorDto.ScheduleId);
                if (schedule == null)
                    return new RequestResult<RequestAnswer>(RequestAnswer.ScheduleProfessorCreateError, true);

                ScheduleProfessor model = new ScheduleProfessor();
                model.Professor = professor;
                model.Schedule = schedule;
                var response = await _scheduleProfessorRepository.CreateScheduleProfessor(model);
                if (response.Id == 0)
                    return new RequestResult<RequestAnswer>(RequestAnswer.ScheduleProfessorCreateError, true);

                return new RequestResult<RequestAnswer>(RequestAnswer.ScheduleProfessorCreateSuccess);
            }
            catch (Exception ex)
            {
                return new RequestResult<RequestAnswer>(RequestAnswer.ScheduleProfessorCreateError, true, ex.Message);
            }
        }

        public async Task<RequestResult<ScheduleProfessorMinDto>> GetScheduleProfessorById(int id)
        {
            try
            {
                var model = await _scheduleProfessorRepository.GetScheduleProfessorById(id);

                if (model == null)
                    return new RequestResult<ScheduleProfessorMinDto>(null, true, RequestAnswer.ScheduleProfessorNotFound.GetDescription());

                var dto = _Mapper.Map<ScheduleProfessorMinDto>(model);
                dto.Professor = _Mapper.Map<ProfessorDto>(model.Professor);
                dto.Schedule = _Mapper.Map<ScheduleDto>(model.Schedule);
                var result = new RequestResult<ScheduleProfessorMinDto>(dto);

                return result;
            }
            catch (Exception ex)
            {
                return new RequestResult<ScheduleProfessorMinDto>(null, true, ex.Message);
            }
        }

        public async Task<RequestResult<RequestAnswer>> UpdateScheduleProfessor(ScheduleProfessorDto scheduleProfessorDto, int id)
        {
            try
            {
                var databaseObj = await _scheduleProfessorRepository.GetScheduleProfessorById(id);
                if(scheduleProfessorDto.ScheduleId > 0){
                    var schedule = await _scheduleRepository.GetScheduleById(scheduleProfessorDto.ScheduleId);
                    if(schedule != null) {
                        databaseObj.Schedule = schedule;
                    }
                }

                if(scheduleProfessorDto.ProfessorId > 0){
                    var professor = await _professorRepository.GetProfessorById(scheduleProfessorDto.ProfessorId);
                    if(professor != null) {
                        databaseObj.Professor = professor;
                    }
                }

                await _scheduleProfessorRepository.UpdateScheduleProfessor(databaseObj);

                return new RequestResult<RequestAnswer>(RequestAnswer.ScheduleProfessorUpdateSuccess);
            }
            catch (Exception ex)
            {
                return new RequestResult<RequestAnswer>(RequestAnswer.ScheduleProfessorUpdateError, true, ex.Message);
            }
        }

        public async Task<RequestResult<RequestAnswer>> DeleteScheduleProfessor(int id)
        {
            try
            {
                await _scheduleProfessorRepository.DeleteScheduleProfessor(id);

                return new RequestResult<RequestAnswer>(RequestAnswer.ScheduleProfessorDeleteSuccess);
            }
            catch (Exception ex)
            {
                return new RequestResult<RequestAnswer>(RequestAnswer.ScheduleProfessorDeleteError, true, ex.Message);
            }
        }
    }
}
