using System;
using Contracts.Interfaces.Services;
using Contracts.RequestHandle;
using System.Threading.Tasks;
using Contracts.Entities;
using Contracts.Dto.Patient;

namespace Business.Services
{
    public class PatientService : IPatientService
    {
        public Task<RequestResult<RequestAnswer>> CreatePatient(PatientDto patientDto)
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
        public Task<RequestResult<PatientDto>> GetPatientById(int id)
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
        public Task<RequestResult<RequestAnswer>> UpdatePatient(PatientDto patientDto)
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
        public Task<RequestResult<RequestAnswer>> DeletePatient(int id)
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
