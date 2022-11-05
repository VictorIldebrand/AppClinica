using System;
using Contracts.Interfaces.Services;
using Contracts.RequestHandle;
using System.Threading.Tasks;
using Contracts.Entities;
using Contracts.Interfaces.Repositories;
using Contracts.Dto.ScheduleProfessor;
using AutoMapper;
using Microsoft.Extensions.Configuration;

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


        public async  Task<RequestResult<RequestAnswer>> CreateScheduleProfessor(ScheduleProfessorDto ScheduleProfessorDto)
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



        public async Task<RequestResult<ScheduleProfessorDto>> GetScheduleProfessorById(int id)
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

        public async Task<RequestResult<RequestAnswer>> UpdateScheduleProfessor(ScheduleProfessorDto ScheduleProfessorDto)
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
        
        public async Task<RequestResult<RequestAnswer>> DeleteScheduleProfessor(int id)
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
