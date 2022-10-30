using Contracts.Entities;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Repositories {
    public interface IPatientRepository {
        Task<Patient> GetPatientById(int id);
        Task<Patient> GetPatientByEmailAndPassword(string email, string password);
        Task<Patient> GetPatientByEmail(string email);
    }
}