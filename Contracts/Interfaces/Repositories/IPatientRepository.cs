using Contracts.Entities;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Repositories {
    public interface IPatientRepository {
        Task<Patient> CreatePatient(Patient patient);
        Task<Patient> GetPatientById(int id);
        Task<Patient[]> GetAllPatients();
        Task<Patient> GetPatientByEmailAndPassword(string email, string password);
        Task<bool> CheckIfPatientExistsByEmail(string email);
        Task<Patient> GetPatientByEmail(string email);
        Task UpdatePatient(Patient patient);
        Task DeletePatient(int id);
 
    }
}
