using Contracts.DTO.Patient;
using Contracts.RequestHandle;
using Contracts.TransactionObjects.Login;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Services {
    public interface IPatientService {
        Task<RequestResult<RequestAnswer>> CreatePatient(PatientDTO patientDTO);
        Task<RequestResult<PatientDTO>> GetPatientById(int id);
        Task<RequestResult<RequestAnswer>> UpdatePatient(PatientDTO PatientDTO);
        Task<RequestResult<RequestAnswer>> DeletePatient(int id);
    }
}
