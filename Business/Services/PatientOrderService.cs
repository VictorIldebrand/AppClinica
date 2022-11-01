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

        public Task<RequestResult<PatientOrderDto>> CreatePatientOrder(PatientOrderDto registerRequest)
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

        public Task<RequestResult<RequestAnswer>> UpdatePatientOrder(PatientOrderDto patient_order)
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

        public Task<RequestResult<RequestAnswer>> DeletePatientOrder(int id)
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

        public Task<RequestResult<PatientOrderDto>> GetPatientOrderById(int id) {
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
