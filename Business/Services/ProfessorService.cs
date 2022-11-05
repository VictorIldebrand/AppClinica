using System;
using Contracts.Interfaces.Services;
using Contracts.RequestHandle;
using System.Threading.Tasks;
using Contracts.Entities;
using Contracts.Interfaces.Repositories;
using Contracts.Dto.Professor;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace Business.Services
{
    public class ProfessorService : IProfessorService
    {
        private readonly IMapper _Mapper;
        private readonly IConfiguration _configuration;
        private readonly IProfessorRepository _professorRepository;

        public ProfessorService(IMapper Mapper, IConfiguration configuration, IProfessorRepository professorRepository)
        {
            _Mapper = Mapper;
            _configuration = configuration;
            _professorRepository = professorRepository;
        }

        public async Task<RequestResult<ProfessorDto>> CreateProfessor(ProfessorDto ProfessorDto)
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

        public async Task<RequestResult<ProfessorDto>> GetProfessorById(int id)
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

        public async Task<RequestResult<RequestAnswer>> UpdateProfessor(ProfessorDto ProfessorDto)
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
        
        public async Task<RequestResult<RequestAnswer>> DeleteProfessor(int id)
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
