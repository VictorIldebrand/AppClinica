using Contracts.Dto.Patient;
using Contracts.RequestHandle;
using Contracts.TransactionObjects.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Services {
    public interface IPatientService {
        Task<RequestResult<RequestAnswer>> CreatePatient(PatientDto patientDTO);
        Task<RequestResult<PatientDto>> GetPatientById(int id);
        Task<IEnumerable<FilterInfoDto>> GetAllPatients();
        Task<RequestResult<RequestAnswer>> UpdatePatient(PatientDto PatientDTO, int id);
        Task<RequestResult<RequestAnswer>> DeletePatient(int id);
    }
}
