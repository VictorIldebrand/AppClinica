using Contracts.Entities;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Repositories {
    public interface IPatientRequestRepository {
        Task<PatientRequest> GetPatientRequestByStudentId(int idStudent);
        Task<PatientRequest> GetPatientRequestById(int id);
        Task<PatientRequest> CreatePatientRequest(PatientRequest patientRequest);
        Task<bool> CheckIfPatientRequestExistsById(int id);
        Task UpdatePatientRequest(PatientRequest patientRequest);
        Task DeletePatientRequest(int id);
    }
}
