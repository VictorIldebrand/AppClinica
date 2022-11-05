using AutoMapper;
using Contracts.Dto.Patient;
using Contracts.Dto.PatientOrder;
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
    public class PatientOrderService : IPatientOrderService
    {
        private readonly IMapper _Mapper;
        private readonly IConfiguration _configuration;
        private readonly IPatientOrderRepository _patientOrderRepository;

        public PatientOrderService(IMapper Mapper, IConfiguration configuration, IPatientOrderRepository patientOrderRepository)
        {
            _Mapper = Mapper;
            _configuration = configuration;
            _patientOrderRepository = patientOrderRepository;
        }

        public async Task<RequestResult<PatientOrderDto>> CreatePatientOrder(PatientOrderDto registerRequest)
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

        public async Task<RequestResult<RequestAnswer>> UpdatePatientOrder(PatientOrderDto patient_order)
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

        public async Task<RequestResult<RequestAnswer>> DeletePatientOrder(int id)
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

        public async Task<RequestResult<PatientOrderDto>> GetPatientOrderById(int id) {
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
