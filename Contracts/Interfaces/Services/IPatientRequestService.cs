using Contracts.Dto.PatientRequest;
using Contracts.RequestHandle;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Services {
    public interface IPatientRequestService {
        Task<RequestResult<RequestAnswer>> CreatePatientRequest(PatientRequestDto patientRequestDto);
        Task<RequestResult<PatientRequestDto>> GetPatientRequestById(int id);
        Task<RequestResult<RequestAnswer>> UpdatePatientRequest(PatientRequestDto patientRequestDto, int id);
        Task<RequestResult<RequestAnswer>> DeletePatientRequest(int id);
    }
}