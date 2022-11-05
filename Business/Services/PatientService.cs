using System;
using Contracts.Interfaces.Services;
using Contracts.RequestHandle;
using System.Threading.Tasks;
using Contracts.Entities;
using Contracts.Dto.Patient;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Contracts.Interfaces.Repositories;

namespace Business.Services
{
    public class PatientService : IPatientService
    {
        private readonly IMapper _Mapper;
        private readonly IConfiguration _configuration;
        private readonly IPatientRepository _patientRepository;

        public PatientService(IMapper Mapper, IConfiguration configuration, IPatientRepository patientRepository)
        {
            _Mapper = Mapper;
            _configuration = configuration;
            _patientRepository = patientRepository;
        }

        public async Task<RequestResult<PatientDto>> CreatePatient(PatientDto patientDto)
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

        public async Task<RequestResult<PatientDto>> GetPatientById(int id)
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

        public async Task<RequestResult<RequestAnswer>> UpdatePatient(PatientDto patientDto)
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

        public async Task<RequestResult<RequestAnswer>> DeletePatient(int id)
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
