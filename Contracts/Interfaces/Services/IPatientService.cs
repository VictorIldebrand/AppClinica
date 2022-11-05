using Contracts.Dto.Patient;
using Contracts.RequestHandle;
using Contracts.TransactionObjects.Login;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Services {
    public interface IPatientService {
        Task<RequestResult<PatientDto>> CreatePatient(PatientDto patientDTO);
        Task<RequestResult<PatientDto>> GetPatientById(int id);
        Task<RequestResult<RequestAnswer>> UpdatePatient(PatientDto PatientDTO);
        Task<RequestResult<RequestAnswer>> DeletePatient(int id);
    }
}
