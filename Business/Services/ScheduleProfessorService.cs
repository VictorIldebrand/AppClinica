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

namespace Business.Services
{
    public class ScheduleProfessorService : IScheduleProfessorService
    {
        private readonly IMapper _Mapper;
        private readonly IConfiguration _configuration;
        private readonly IScheduleProfessorRepository _scheduleProfessorRepository;

        public ScheduleProfessorService(IMapper Mapper, IConfiguration configuration, IScheduleProfessorRepository scheduleProfessorRepository)
        {
            _Mapper = Mapper;
            _configuration = configuration;
            _scheduleProfessorRepository = scheduleProfessorRepository;
        }

        public async Task<RequestResult<ScheduleProfessorMinDto>> CreateScheduleProfessor(ScheduleProfessorDto ScheduleProfessorDto)
        {
            try
            {
                var model = _Mapper.Map<ScheduleProfessor>(ScheduleProfessorDto);
                var response = await _scheduleProfessorRepository.CreateScheduleProfessor(model);
                if (response.Id == 0)
                    return new RequestResult<ScheduleProfessorMinDto>(null, true, RequestAnswer.ScheduleProfessorCreateError.GetDescription());
                var dto = _Mapper.Map<ScheduleProfessorMinDto>(response);
                return new RequestResult<ScheduleProfessorMinDto>(dto);
            }
            catch (Exception ex)
            {
                return new RequestResult<ScheduleProfessorMinDto>(null, true, ex.Message);
            }
        }

        public async Task<RequestResult<ScheduleProfessorDto>> GetScheduleProfessorById(int id)
        {
            try
            {
                var model = await _scheduleProfessorRepository.GetScheduleProfessorById(id);

                if (model == null)
                    return new RequestResult<ScheduleProfessorDto>(null, true, RequestAnswer.ScheduleProfessorNotFound.GetDescription());

                var dto = _Mapper.Map<ScheduleProfessorDto>(model);
                var result = new RequestResult<ScheduleProfessorDto>(dto);

                return result;
            }
            catch (Exception ex)
            {
                return new RequestResult<ScheduleProfessorDto>(null, true, ex.Message);
            }
        }

        public async Task<RequestResult<RequestAnswer>> UpdateScheduleProfessor(ScheduleProfessorDto scheduleProfessorDto)
        {
            try
            {
                var model = _Mapper.Map<ScheduleProfessor>(scheduleProfessorDto);
                await _scheduleProfessorRepository.UpdateScheduleProfessor(model);

                return new RequestResult<RequestAnswer>(RequestAnswer.ScheduleProfessorUpdateSuccess);
            }
            catch (Exception)
            {
                return new RequestResult<RequestAnswer>(RequestAnswer.ScheduleProfessorUpdateError, true);
            }
        }
        
        public async Task<RequestResult<RequestAnswer>> DeleteScheduleProfessor(int id)
        {
            try
            {
                await _scheduleProfessorRepository.DeleteScheduleProfessor(id);

                return new RequestResult<RequestAnswer>(RequestAnswer.ScheduleProfessorDeleteSuccess);
            }
            catch (Exception)
            {
                return new RequestResult<RequestAnswer>(RequestAnswer.ScheduleProfessorDeleteError, true);
            }
        }
    }
}
