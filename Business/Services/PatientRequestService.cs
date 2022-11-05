using AutoMapper;
using Contracts.Dto.Employee;
using Contracts.Dto.PatientRequest;
using Contracts.DTO.User;
using Contracts.Entities;
using Contracts.Interfaces.Repositories;
using Contracts.Interfaces.Services;
using Contracts.RequestHandle;
using Contracts.TransactionObjects.Login;
using Contracts.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
namespace Business.Services
{
    public class PatientRequestService : IPatientRequestService
    {
        private readonly IMapper _Mapper;
        private readonly IConfiguration _configuration;
        private readonly IPatientRequestRepository _patientRequestRepository;

        public PatientRequestService(IMapper Mapper, IConfiguration configuration, IPatientRequestRepository patientRequestRepository)
        {
            _Mapper = Mapper;
            _configuration = configuration;
            _patientRequestRepository = patientRequestRepository;
        }

        public async Task<RequestResult<PatientRequestDto>> CreatePatientRequest(PatientRequestDto patientRequestDto)
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

        public async Task<RequestResult<PatientRequestDto>> GetPatientRequestById(int id)
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

        public async Task<RequestResult<RequestAnswer>> UpdatePatientRequest(PatientRequestDto patientRequestDto)
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

        public async Task<RequestResult<RequestAnswer>> DeletePatientRequest(int id)
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
