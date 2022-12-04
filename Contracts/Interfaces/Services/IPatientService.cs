using Contracts.Dto.Patient;
using Contracts.RequestHandle;
using Contracts.TransactionObjects.User;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Services {
    public interface IPatientService {
        Task<RequestResult<RequestAnswer>> CreatePatient(PatientDto patientDTO);
        Task<RequestResult<PatientDto>> GetPatientById(int id);
        Task<FilterInfoDto[]> GetAllPatients();
        Task<RequestResult<RequestAnswer>> UpdatePatient(PatientDto PatientDTO, int id);
        Task<RequestResult<RequestAnswer>> DeletePatient(int id);
    }
}
